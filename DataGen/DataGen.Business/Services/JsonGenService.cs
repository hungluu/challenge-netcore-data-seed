using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Linq;
using System;
using System.Threading.Tasks;
using System.IO;
using System.Threading.Tasks.Dataflow;
using DataGen.Business.ServiceModels;
using System.Text;

namespace DataGen.Business.Services
{
    public interface IJsonGenService
    {
        Task GenerateFromTemplate(JsonServiceModel jsonServiceModel);
        Task GenerateFromTemplate(JsonServiceModel jsonServiceModel, int splittedItemCount);
    }

    public class JsonGenService : IJsonGenService
    {
        private readonly ITokenService _tokenService;
        private readonly ITemplateService _templateService;

        public JsonGenService(ITokenService tokenService, ITemplateService templateService)
        {
            _tokenService = tokenService;
            _templateService = templateService;
        }

        public Task GenerateFromTemplate(JsonServiceModel jsonServiceModel)
        {
            File.WriteAllTextAsync(jsonServiceModel.OutputPath, "[").Wait();

            var batch = new BatchBlock<string>(500);
            var writeFileAction = new ActionBlock<string[]>((string[] rows) =>
            {
                File.AppendAllText(jsonServiceModel.OutputPath, string.Join(Environment.NewLine, rows));

                jsonServiceModel.StepCallback?.Invoke(rows.Length);
            });

            batch.LinkTo(writeFileAction);
            batch.Completion.ContinueWith(delegate {
                writeFileAction.Complete();
            });

            var tokens = _templateService.GetTokens(jsonServiceModel.TemplateText);
            var lastIndex = jsonServiceModel.Count - 1;
            string lastRowCharacter;
            string generatedRowTest;
            for (var x = 0; x < jsonServiceModel.Count; x++)
            {
                lastRowCharacter = x != lastIndex ? "," : "]";
                generatedRowTest = _templateService.GenerateRow(jsonServiceModel.TemplateText, tokens) + lastRowCharacter;

                batch.Post(MinifyJson(generatedRowTest));
            }
            batch.Complete();

            return writeFileAction.Completion;
        }

        public Task GenerateFromTemplate(JsonServiceModel jsonServiceModel, int splittedItemCount)
        {
            File.WriteAllTextAsync(jsonServiceModel.OutputPath, "[").Wait();

            int batchSize = 500;
            int totalCount = jsonServiceModel.Count;
            var calculatedResources = CalculateResources(totalCount, splittedItemCount);

            var partCount = calculatedResources.Item1;
            var partItemCounts = calculatedResources.Item2;

            List<Task> taskList = new List<Task>();

            var mainWriteAction = new ActionBlock<string[]>(rows =>
            {
                using (FileStream fs = new FileStream(
                    jsonServiceModel.OutputPath,
                    FileMode.Append,
                    FileAccess.Write
                ))
                using (StreamWriter sw = new StreamWriter(fs, Encoding.UTF8))
                {
                    sw.Write(string.Join(Environment.NewLine, rows));
                }

                jsonServiceModel.StepCallback?.Invoke(rows.Length);
            });

            var lastPartIndex = partCount - 1;
            for (var i = 0; i < partCount; i++)
            {
                var outputPath = $"{jsonServiceModel.OutputPath}.part{i}";
                var batch = new BatchBlock<string>(batchSize);
                var itemCount = partItemCounts[i];

                batch.LinkTo(mainWriteAction);

                Task.Factory.StartNew(() =>
                {
                    var tokens = _templateService.GetTokens(jsonServiceModel.TemplateText);
                    var lastItemIndex = itemCount - 1;
                    string generatedRowTest;

                    for (var x = 0; x < itemCount; x++)
                    {
                        string lastRowCharacter = i != lastPartIndex || x != lastItemIndex ? "," : "]";
                        generatedRowTest = _templateService.GenerateRow(
                            MinifyJson(jsonServiceModel.TemplateText),
                            tokens
                        );

                        batch.Post(generatedRowTest + lastRowCharacter);
                    }

                    if(i == lastPartIndex)
                    {
                        batch.Completion.ContinueWith(delegate
                        {
                            mainWriteAction.Complete();
                        });
                    }

                    batch.Complete();
                });
            }

            return mainWriteAction.Completion;
        }

        public Tuple<int, int[]> CalculateResources(int totalCount, int splittedItemCount)
        {
            var maxPartCount = Environment.ProcessorCount;
            var minPartCount = 1;

            if (totalCount < 500000)
            {
                maxPartCount = Environment.ProcessorCount / 2;
            } else if (totalCount < 1000000)
            {
                maxPartCount = Environment.ProcessorCount * 3 / 4;
            }

            int partCount;
            int[] partItemCounts;

            partCount = totalCount / splittedItemCount;

            if (partCount > maxPartCount)
            {
                partCount = maxPartCount;
                splittedItemCount = totalCount / partCount;
            }
            else if (partCount < minPartCount)
            {
                partCount = minPartCount;
                splittedItemCount = totalCount / partCount;
            }

            partItemCounts = Enumerable.Repeat(splittedItemCount, partCount).ToArray();

            partItemCounts[partItemCounts.Length - 1] += totalCount % splittedItemCount;

            return new Tuple<int, int[]>(partCount, partItemCounts);
        }

        public string MinifyJson(string jsonText) {
            return Regex.Replace(jsonText, @"(""[^""\\]*(?:\\.[^""\\]*)*"")|\s+", "$1");
        }
    }
}
