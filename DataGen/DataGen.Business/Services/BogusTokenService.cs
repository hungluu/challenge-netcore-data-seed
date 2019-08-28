using Newtonsoft.Json;
using System.Text.RegularExpressions;
using Bogus;
using Bogus.DataSets;

namespace DataGen.Business.Services
{
    public interface IBogusTokenService
    {
        string GetAddress(string token);
        string GetCommerce(string token);
        string GetSystem(string token);

    }

    public class BogusTokenService: IBogusTokenService
    {
        const string Locale = "vi";
        const int DefaultCount = 5;

        private readonly Address _address;
        private readonly Commerce _commerce;
        private readonly Company _company;
        private readonly Bogus.DataSets.Database _db;
        private readonly Bogus.DataSets.System _system;
        private readonly Randomizer _randomizer;
        private readonly Date _date;
        private readonly string _systemWithMinMaxParamsPattern;
        private readonly string _systemWithCountParamsPattern;
        private readonly string _systemWithItemListPattern;
        private readonly string _systemWithFormatPattern;
        private readonly string _paramsSplitPattern = @"[,\s]+";

        public BogusTokenService()
        {
            _address = new Address(Locale);
            _commerce = new Commerce(Locale);
            _company = new Company(Locale);
            _db = new Bogus.DataSets.Database();
            _system = new Bogus.DataSets.System();
            _randomizer = new Randomizer();
            _date = new Date();

            var withMinMaxParamsTokenNames = new string[] {
                "Number",
                "Even",
                "Odd",
                "Double",
                "Decimal",
                "Float",
                "Int",
                "Long"
            };
            var withCountParamTokenNames = new string[]
            {
                "Digits",
                "Chars",
                "Hash",
                "AlphaNumeric",
                "String",
                "Hexadecimal",
                "Words",
                "Number",
                "Even",
                "Odd",
                "Double",
                "Decimal",
                "Float",
                "Int",
                "Long"
            };
            var withItemListTokenNames = new string[]
            {
                "ArrayElement",
                "ArrayElements"
            };
            var withFormatTokenNames = new string[]
            {
                "Past"
            };

            _systemWithMinMaxParamsPattern = GetMinMaxPatternForTokens(withMinMaxParamsTokenNames);
            _systemWithCountParamsPattern = GetCountPatternForTokens(withCountParamTokenNames);
            _systemWithItemListPattern = GetItemListPatternForTokens(withItemListTokenNames);
            _systemWithFormatPattern = GetFormatPatternForTokens(withFormatTokenNames);
        }

        public string GetAddress (string token)
        {
            switch (token)
            {
                case "ZipCode": return _address.ZipCode();
                case "City": return _address.City();
                case "StreetAddress": return _address.StreetAddress();
                case "CityPrefix": return _address.CityPrefix();
                case "CitySuffix": return _address.CitySuffix();
                case "StreetName": return _address.StreetName();
                case "BuildingNumber": return _address.BuildingNumber();
                case "StreetSuffix": return _address.StreetSuffix();
                case "SecondaryAddress": return _address.SecondaryAddress();
                case "County": return _address.County();
                case "Country": return _address.Country();
                case "FullAddress": return _address.FullAddress();
                case "CountryCode": return _address.CountryCode();
                case "State": return _address.State();
                case "StateAbbr": return _address.StateAbbr();
                case "Latitude": return _address.Latitude().ToString();
                case "Longitude": return _address.Longitude().ToString();
                case "Direction": return _address.Direction();
                case "CardinalDirection": return _address.CardinalDirection();
                case "OrdinalDirection": return _address.OrdinalDirection();
                default: return null;
            };
        }

        public string GetCommerce (string token)
        {
            switch (token)
            {
                case "Department": return _commerce.Department();
                case "Price": return _commerce.Price();
                case "Categories": return JsonConvert.SerializeObject(_commerce.Categories(DefaultCount));
                case "ProductName": return _commerce.ProductName();
                case "Color": return _commerce.Color();
                case "Product": return _commerce.Product();
                case "ProductAdjective": return _commerce.ProductAdjective();
                case "ProductMaterial": return _commerce.ProductMaterial();
                case "Ean8": return _commerce.Ean8();
                case "Ean13": return _commerce.Ean13();
                case "CompanySuffix": return _company.CompanySuffix();
                case "CompanyName": return _company.CompanyName();
                case "CompanyCatchPhrase": return _company.CatchPhrase();
                case "CompanyBs": return _company.Bs();
                default: return null;
            }
        }

        public string GetSystem (string token)
        {
            switch (token)
            {
                case "Column": return _db.Column();
                case "DataType": return _db.Type();
                case "Collation": return _db.Collation();
                case "DatabaseEngine": return _db.Engine();
                case "FileName": return _system.FileName();
                case "DirectoryPath": return _system.DirectoryPath();
                case "FilePath": return _system.FilePath();
                case "MimeType": return _system.MimeType();
                case "CommonFileType": return _system.CommonFileType();
                case "CommonFileExt": return _system.CommonFileExt();
                case "FileType": return _system.FileType();
                case "FileExt": return _system.FileExt();
                case "Semver": return _system.Semver();
                case "Version": return _system.Version().ToString();
                case "Exception": return _system.Exception().Message;
                case "AndroidId": return _system.AndroidId();
                case "ApplePushToken": return _system.ApplePushToken();
                case "BlackBerryPin": return _system.BlackBerryPin();
                case "Bool": return _randomizer.Bool().ToString();
                case "Guid": return _randomizer.Guid().ToString();
                case "Uuid": return _randomizer.Uuid().ToString();
                case "RandomLocale": return _randomizer.RandomLocale();
                case "Hexadecimal": return _randomizer.Hexadecimal();
                case "Char": return _randomizer.Char().ToString();
                case "Double": return _randomizer.Double().ToString();
                case "Decimal": return _randomizer.Decimal().ToString();
                case "Float": return _randomizer.Float().ToString();
                case "Int": return _randomizer.Int().ToString();
                case "String": return _randomizer.String();
                case "Hash": return _randomizer.Hash();
                case "Word": return _randomizer.Word();
                case "Words": return _randomizer.Words();
                case "Number": return _randomizer.Number().ToString();
                case "Even": return _randomizer.Even().ToString();
                case "Odd": return _randomizer.Odd().ToString();
                case "Long": return _randomizer.Long().ToString();
                default:
                    return GetSystemCountToken(token) ??
                        GetSystemMinMaxToken(token) ??
                        GetSystemItemListToken(token) ??
                        GetSystemDateToken(token);
            }
        }

        private string GetSystemMinMaxToken (string token)
        {
            var match = Regex.Match(token, _systemWithMinMaxParamsPattern);

            if (match.Success)
            {
                int.TryParse(match.Groups["min"].Value, out int min);
                int.TryParse(match.Groups["max"].Value, out int max);

                switch (match.Groups["tokenName"].Value)
                {
                    case "Number": return _randomizer.Number(min, max).ToString();
                    case "Even": return _randomizer.Even(min, max).ToString();
                    case "Odd": return _randomizer.Odd(min, max).ToString();
                    case "Double": return _randomizer.Double(min, max).ToString();
                    case "Decimal": return _randomizer.Decimal(min, max).ToString();
                    case "Float": return _randomizer.Float(min, max).ToString();
                    case "Int": return _randomizer.Int(min, max).ToString();
                    case "Long": return _randomizer.Long(min, max).ToString();
                    default: return null;
                }
            }
            else
            {
                return null;
            }
        }

        private string GetSystemCountToken (string token)
        {
            var match = Regex.Match(token, _systemWithCountParamsPattern);

            if (match.Success)
            {
                int.TryParse(match.Groups["count"].Value, out int count);

                switch (match.Groups["tokenName"].Value)
                {
                    case "Digits": return string.Join(',', _randomizer.Digits(count: count));
                    case "Chars": return JsonConvert.SerializeObject(_randomizer.Chars(count: count));
                    case "Hash": return _randomizer.Hash(length: count).ToString();
                    case "AlphaNumeric": return _randomizer.AlphaNumeric(length: count);
                    case "String": return _randomizer.String(length: count);
                    case "Hexadecimal": return _randomizer.Hexadecimal(length: count);
                    case "Words": return _randomizer.Words(count);
                    case "Number": return _randomizer.Number(max: count).ToString();
                    case "Even": return _randomizer.Even(min: count, int.MaxValue).ToString();
                    case "Odd": return _randomizer.Odd(min: count, int.MaxValue).ToString();
                    case "Double": return _randomizer.Double(min: count, double.MaxValue).ToString();
                    case "Decimal": return _randomizer.Decimal(min: count, decimal.MaxValue).ToString();
                    case "Float": return _randomizer.Float(min: count, float.MaxValue).ToString();
                    case "Int": return _randomizer.Int(min: count).ToString();
                    case "Long": return _randomizer.Long(min: count).ToString();
                    default: return null;
                }
            }
            else
            {
                return null;
            }
        }

        private string GetSystemDateToken(string token)
        {
            var match = Regex.Match(token, _systemWithFormatPattern);
            string dateFormat;

            if (match.Success)
            {
                dateFormat = match.Groups["format"].Value;
                switch (match.Groups["tokenName"].Value)
                {
                    case "Past": return _date.Past().ToString(dateFormat);
                    default: return null;
                }
            }
            else
            {
                return null;
            }
        }

        private string GetSystemItemListToken (string token)
        {
            var match = Regex.Match(token, _systemWithItemListPattern);
            string[] parameters;

            if (match.Success)
            {
                parameters = Regex.Split(match.Groups["params"].Value, _paramsSplitPattern);

                switch (match.Groups["tokenName"].Value)
                {
                    case "ArrayElement": return _randomizer.ArrayElement(parameters);
                    case "ArrayElements": return string.Join(',', _randomizer.ArrayElements(parameters));
                    default: return null;
                }
            }
            else
            {
                return null;
            }
        }

        private string GetFormatPatternForTokens(object[] tokenNames)
        {
            var jointTokenNames = string.Join('|', tokenNames);

            return $@"^(?<tokenName>{jointTokenNames})\((?<format>[^)]+)\)$";
        }

        private string GetCountPatternForTokens (object[] tokenNames)
        {
            var jointTokenNames = string.Join('|', tokenNames);

            return $@"^(?<tokenName>{jointTokenNames})\((?<count>-?\d+)\)$";
        }

        private string GetMinMaxPatternForTokens (object[] tokenNames)
        {
            var jointTokenNames = string.Join('|', tokenNames);

            return $@"^(?<tokenName>{jointTokenNames})\((?<min>-?\d+), *(?<max>-?\d+)\)$";
        }

        private string GetItemListPatternForTokens(object[] tokenNames)
        {
            var jointTokenNames = string.Join('|', tokenNames);

            return $@"^(?<tokenName>{jointTokenNames})\((?<items>[^(),\s]+(?:,\s*[^(),\s]+)+)\)$";
        }
    }
}
