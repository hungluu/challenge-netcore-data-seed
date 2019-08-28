using DataGen.App.Infrastructure;
using DataGen.App.Views;
using DataGen.Business.ServiceModels;
using DataGen.Business.Services;
using DataGen.App.ViewModels;
using System;
using System.IO;
using System.Threading.Tasks;

namespace DataGen.App.Controllers
{
    class JsonController: BaseController
    {
        private readonly IJsonGenService _jsonGenService;

        public JsonController (IJsonGenService jsonGenService)
        {
            _jsonGenService = jsonGenService;
        }

        public async Task GetIndex(JsonViewModel jsonViewModel)
        {
            var templatePath = jsonViewModel.FilePath;
            var templateFileName = Path.GetFileNameWithoutExtension(templatePath);
            var outputDir = jsonViewModel.OutputDir ?? Path.GetDirectoryName(templatePath);
            var outputName = jsonViewModel.OutputName ?? DateTime.Now.ToString("yyyyMMdd-HHmmss") + $@"-{jsonViewModel.Count}-{templateFileName}.json";
            var outputPath = Path.Combine(outputDir, outputName);
            var view = new JsonView(new JsonViewModel {
                Count = jsonViewModel.Count,
                Message = string.Join(
                    Environment.NewLine,
                    $@"Building {jsonViewModel.Count} samples from {templatePath}",
                    $@"Output: {outputPath}"
                )
            });

            view.Render();
            await _jsonGenService.GenerateFromTemplate(new JsonServiceModel
            {
                OutputPath = outputPath,
                Count = jsonViewModel.Count,
                TemplateText = File.ReadAllText(templatePath),
                StepCallback = (int stepCount) =>
                {
                    view.Step(stepCount);

                    return true;
                }
            }, 50000);

            view.Dispose();
        }
    }
}
