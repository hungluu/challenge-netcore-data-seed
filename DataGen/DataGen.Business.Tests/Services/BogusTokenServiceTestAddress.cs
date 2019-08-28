using NUnit.Framework;
using System;
using System.Text.RegularExpressions;

namespace DataGen.Business.Tests.Services
{
    partial class BogusTokenServiceTest
    {
        // ZipCode
        [Test]
        public void TestShouldGetZipCode()
        {
            var result = _tokenService.GetAddress("ZipCode");
            Assert.GreaterOrEqual(result.Length, 3);
            Assert.IsTrue(Regex.Match(result, ZipCodePattern).Success);
        }

        // City
        [Test]
        public void TestShouldGetCity()
        {
            var result = _tokenService.GetAddress("City");
            Assert.GreaterOrEqual(result.Length, 3);
        }

        // StreetAddress
        [Test]
        public void TestShouldGetStreetAddress()
        {
            var result = _tokenService.GetAddress("StreetAddress");
            Assert.GreaterOrEqual(result.Length, 3);
        }

        // CityPrefix
        [Test]
        public void TestShouldGetCityPrefix()
        {
            var result = _tokenService.GetAddress("CityPrefix");
            Assert.GreaterOrEqual(result.Length, 3);
        }

        // CitySuffix
        [Test]
        public void TestShouldGetCitySuffix()
        {
            var result = _tokenService.GetAddress("CitySuffix");
            Assert.GreaterOrEqual(result.Length, 2);
        }

        // StreetName
        [Test]
        public void TestShouldGetStreetName()
        {
            var result = _tokenService.GetAddress("StreetName");
            Assert.GreaterOrEqual(result.Length, 3);
        }

        // BuildingNumber
        [Test]
        public void TestShouldGetBuildingNumber()
        {
            var result = _tokenService.GetAddress("BuildingNumber");
            Assert.GreaterOrEqual(result.Length, 1);
        }

        // StreetSuffix
        [Test]
        public void TestShouldGetStreetSuffix()
        {
            var result = _tokenService.GetAddress("StreetSuffix");
            Assert.GreaterOrEqual(result.Length, 1);
        }

        // SecondaryAddress
        [Test]
        public void TestShouldGetSecondaryAddress()
        {
            var result = _tokenService.GetAddress("SecondaryAddress");
            Assert.GreaterOrEqual(result.Length, 3);
        }

        // County
        [Test]
        public void TestShouldGetCounty()
        {
            var result = _tokenService.GetAddress("County");
            Assert.GreaterOrEqual(result.Length, 3);
        }

        // Country
        [Test]
        public void TestShouldGetCountry()
        {
            var result = _tokenService.GetAddress("Country");
            Assert.GreaterOrEqual(result.Length, 3);
        }

        // FullAddress
        [Test]
        public void TestShouldGetFullAddress()
        {
            var result = _tokenService.GetAddress("FullAddress");
            Assert.GreaterOrEqual(result.Length, 3);
        }

        // CountryCode
        [Test]
        public void TestShouldGetCountryCode()
        {
            var result = _tokenService.GetAddress("CountryCode");
            Assert.GreaterOrEqual(result.Length, 2);
        }

        // State
        [Test]
        public void TestShouldGetState()
        {
            var result = _tokenService.GetAddress("State");
            Assert.GreaterOrEqual(result.Length, 3);
        }

        // StateAbbr
        [Test]
        public void TestShouldGetStateAbbr()
        {
            var result = _tokenService.GetAddress("StateAbbr");
            Assert.GreaterOrEqual(result.Length, 2);
        }

        // Latitude
        [Test]
        public void TestShouldGetLatitude()
        {
            var result = _tokenService.GetAddress("Latitude");
            Assert.IsTrue(Regex.Match(result, LongLatRegexPattern).Success);
        }

        // Longitude
        [Test]
        public void TestShouldGetLongitude()
        {
            var result = _tokenService.GetAddress("Longitude");
            Assert.IsTrue(Regex.Match(result, LongLatRegexPattern).Success);
        }

        // Direction
        [Test]
        public void TestShouldGetDirection()
        {
            var result = _tokenService.GetAddress("Direction");
            Assert.GreaterOrEqual(result.Length, 3);
        }

        // CardinalDirection
        [Test]
        public void TestShouldGetCardinalDirection()
        {
            var result = _tokenService.GetAddress("CardinalDirection");
            Assert.GreaterOrEqual(result.Length, 3);
        }

        // OrdinalDirection
        [Test]
        public void TestShouldGetOrdinalDirection()
        {
            var result = _tokenService.GetAddress("OrdinalDirection");
            Assert.GreaterOrEqual(result.Length, 3);
        }
    }
}
