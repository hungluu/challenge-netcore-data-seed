using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Linq;
using DataGen.Business.ServiceModels;

namespace DataGen.Business.Services
{
    public interface ITemplateService
    {
        string GenerateRow(string templateText, IEnumerable<string> tokens);
        IEnumerable<string> GetTokens(string text);
        IEnumerable<TokenInfoServiceModel> GenerateFromTokens(IEnumerable<string> tokenList);
    }

    public class TemplateService : ITemplateService
    {
        const string TokenRegex = @"{{([^{}:\s]+|:[\w\d_]+|[^{}:\s]+:[\w\d_]+)}}";
        private readonly ITokenService _tokenService;

        public TemplateService(ITokenService tokenService)
        {
            _tokenService = tokenService;
        }

        public IEnumerable<TokenInfoServiceModel> GenerateFromTokens(IEnumerable<string> tokenList)
        {
            var savedNamedTokens = new Dictionary<string, string>();
            var result = new List<TokenInfoServiceModel>();
            var parsedNameList = new List<string>();
            string generatedToken;
            string tokenName;
            string token;
            string rawText;
            int separatorPos;

            foreach (string tokenItem in tokenList)
            {
                rawText = "{{" + tokenItem + "}}";
                separatorPos = tokenItem.IndexOf(":");
                if (separatorPos == -1)
                {
                    token = tokenItem;
                    generatedToken = _tokenService.Generate(token);
                    result.Add(new TokenInfoServiceModel
                    {
                        RawText = rawText,
                        Replacement = generatedToken
                    });
                }
                else if (separatorPos > 0)
                {
                    var tokenParts = tokenItem.Split(":");
                    tokenName = tokenParts[1];

                    if (savedNamedTokens.ContainsKey(tokenName))
                    {
                        continue;
                    }

                    token = tokenParts[0];
                    generatedToken = _tokenService.Generate(token);
                    savedNamedTokens.Add(tokenName, generatedToken);
                    result.Add(new TokenInfoServiceModel
                    {
                        RawText = rawText,
                        Replacement = generatedToken
                    });
                } else
                {
                    var tokenParts = tokenItem.Split(":");
                    tokenName = tokenParts[1];

                    if (parsedNameList.Contains(tokenName))
                    {
                        continue;
                    }
                    parsedNameList.Add(tokenName);

                    savedNamedTokens.TryGetValue(tokenName, out generatedToken);

                    result.Add(new TokenInfoServiceModel
                    {
                        RawText = rawText,
                        Replacement = generatedToken
                    });
                }
            }

            return result;
        }

        public string GenerateRow(string templateText, IEnumerable<string> tokens)
        {
            IEnumerable<TokenInfoServiceModel> generatedTokenInfos = GenerateFromTokens(tokens);
            var rowText = templateText;
            var tokenInfos = GenerateFromTokens(tokens);

            foreach (TokenInfoServiceModel tokenInfo in generatedTokenInfos)
            {
                rowText = rowText.Replace(tokenInfo.RawText, tokenInfo.Replacement);
            }

            return rowText;
        }

        public IEnumerable<string> GetTokens(string text)
        {
            return Regex.Matches(text, TokenRegex).Select(match => match.Groups[1].Value).Distinct().ToArray();
        }
    }
}
