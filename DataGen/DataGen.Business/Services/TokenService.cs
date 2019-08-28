using Faker;
using System.Text.RegularExpressions;
using System.Linq;
using System;

namespace DataGen.Business.Services
{
    public interface ITokenService
    {
        string Generate(string token);
        string GenerateLorem(string token);
        string GenerateNumber(string token);
        string GeneratePerson(string token);
        string GenerateCompany(string token);
    }

    public class TokenService: ITokenService
    {
        const string WordsRegex = @"(Words)\((\d+)\)";
        const string SentencesRegex = @"(Sentences)\((\d+)\)";
        const string ParagraphsRegex = @"(Paragraphs)\((\d+)\)";
        const string RandomNumberMaxRegex = @"(RandomNumberMax)\((\d+)\)";
        const string RandomNumberMinMaxRegex = @"(RandomNumberMinMax)\((\d+), *(\d+)\)";

        public string Generate(string token)
        {
            return GeneratePerson(token) ??
                GenerateCompany(token) ??
                GenerateLorem(token) ??
                GenerateNumber(token);
        }

        public string GenerateLorem(string token)
        {
            switch (token)
            {
                case "Sentence": return Lorem.Sentence();
                case "Paragraph": return Lorem.Paragraph();
                default:
                    Tuple<string, int[]> testResult;

                    testResult = GetTokenInfo(token, WordsRegex);
                    if (testResult.Item1 != "")
                    {
                        return string.Join(' ', Lorem.Words(testResult.Item2[0]));
                    }

                    testResult = GetTokenInfo(token, SentencesRegex);
                    if (testResult.Item1 != "")
                    {
                        return string.Join(". ", Lorem.Sentences(testResult.Item2[0]));
                    }

                    testResult = GetTokenInfo(token, ParagraphsRegex);
                    if (testResult.Item1 != "")
                    {
                        return string.Join("\n", Lorem.Paragraphs(testResult.Item2[0]));
                    }

                    return null;
            }
        }

        public string GenerateNumber(string token)
        {
            switch(token)
            {
                case "RandomNumber": return RandomNumber.Next().ToString();
                default:
                    Tuple<string, int[]> testResult;

                    testResult = GetTokenInfo(token, RandomNumberMaxRegex);
                    if (testResult.Item1 != "")
                    {
                        return RandomNumber.Next(testResult.Item2[0]).ToString();
                    }

                    testResult = GetTokenInfo(token, RandomNumberMinMaxRegex);
                    if (testResult.Item1 != "")
                    {
                        return RandomNumber.Next(testResult.Item2[0], testResult.Item2[1]).ToString();
                    }

                    return null;
            }
        }

        public string GeneratePerson(string token)
        {
            switch(token)
            {
                case "Id": return Guid.NewGuid().ToString();
                case "FullName": return Name.FullName();
                case "FirstName": return Name.First();
                case "LastName": return Name.Last();
                case "PersonPrefix": return Name.Prefix();
                case "PersonSuffix": return Name.Suffix();
                case "PhoneNumber": return Phone.Number();
                case "Country": return Address.Country();
                case "ZipCode": return Address.ZipCode();
                case "UsState": return Address.UsState();
                case "UsStateAbbr": return Address.UsStateAbbr();
                case "CityPrefix": return Address.CityPrefix();
                case "CitySufix": return Address.CitySufix();
                case "City": return Address.City();
                case "StreetSuffix": return Address.StreetSuffix();
                case "StreetName": return Address.StreetName();
                case "StreetAddress": return Address.StreetAddress();
                case "SecondaryAddress": return Address.SecondaryAddress();
                case "UkCounty": return Address.UkCounty();
                case "UkCountry": return Address.UkCountry();
                case "UkPostCode": return Address.UkPostCode();
                case "Email": return Internet.Email();
                case "FreeEmail": return Internet.FreeEmail();
                case "UserName": return Internet.UserName();
                default: return null;
            }
        }

        public string GenerateCompany(string token)
        {
            switch (token)
            {
                case "CompanyName": return Company.Name();
                case "CompanySuffix": return Company.Suffix();
                case "CompanyCatchPhrase": return Company.CatchPhrase();
                case "CompanyBS": return Company.BS();
                case "DomainName": return Internet.DomainName();
                case "DomainWord": return Internet.DomainWord();
                case "DomainSuffix": return Internet.DomainSuffix();
                default: return null;
            }
        }

        public Tuple<string, int[]> GetTokenInfo(string token, string testedRegex)
        {
            string[] matches;
            Match match = Regex.Match(token, testedRegex);
            var tokenFunc = "";
            var tokenArgs = new int[0];

            if (match.Success)
            {
                matches = match.Groups.Skip(1).Select(g => g.Value).ToArray();
                tokenFunc = matches[0];
                tokenArgs = matches.Skip(1).Select(i =>
                {
                    int arg;

                    if (!int.TryParse(i, out arg))
                    {
                        arg = 10;
                    }

                    return arg;
                }).ToArray();
            }

            return new Tuple<string, int[]>(tokenFunc, tokenArgs);
        }
    }
}
