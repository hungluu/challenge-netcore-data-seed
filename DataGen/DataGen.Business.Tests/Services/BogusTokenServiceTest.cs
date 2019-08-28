using DataGen.Business.Services;
using NUnit.Framework;

namespace DataGen.Business.Tests.Services
{
    partial class BogusTokenServiceTest
    {
        const string LongLatRegexPattern = @"^(\-?\d+(\.\d+)?)[.,]\s*(\-?\d+(\.\d+)?)$";
        const string HexadecimalPattern = @"^0[xX][0-9a-fA-F]+$";
        const string AlphaNumbericPattern = @"^[\w\d]+$";
        const string ZipCodePattern = @"^\d{5}(?:[-\s]\d{4})?$";

        private readonly BogusTokenService _tokenService;

        public BogusTokenServiceTest()
        {
            _tokenService = new BogusTokenService();
        }
    }
}
