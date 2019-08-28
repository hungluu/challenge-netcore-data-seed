using DataGen.Business.Services;
using NUnit.Framework;
using System;
using System.Text.RegularExpressions;

namespace DataGen.Business.Tests
{
    public class TokenServiceTest
    {
        private readonly TokenService _tokenService;

        public TokenServiceTest()
        {
            _tokenService = new TokenService();
        }

        [Test]
        public void TestShouldGenerateToken()
        {
            string result = _tokenService.Generate("Id");
            Assert.Greater(result.Length, 1);
        }

        [Test]
        public void TestShouldGenerateLoremSentence()
        {
            string result = _tokenService.GenerateLorem("Sentence");

            Assert.AreNotEqual(result.IndexOf('.'), -1);
            Assert.Greater(result.Length, 1);
        }

        [Test]
        public void TestShouldGenerateLoremParagraph()
        {
            string result = _tokenService.GenerateLorem("Paragraph");

            Assert.AreNotEqual(result.IndexOf("."), 0);
            Assert.Greater(result.Length, 1);
        }

        [Test]
        public void TestShouldGenerateLoremWords()
        {
            string result = _tokenService.GenerateLorem("Words(5)");

            Assert.AreNotEqual(result.IndexOf(" "), 0);
            Assert.Greater(result.Length, 1);
        }

        [Test]
        public void TestShouldGenerateLoremSentences()
        {
            string result = _tokenService.GenerateLorem("Sentences(2)");

            Assert.AreNotEqual(result.IndexOf(". "), 0);
            Assert.Greater(result.Length, 1);
        }

        [Test]
        public void TestShouldGenerateLoremParagraphs()
        {
            string result = _tokenService.GenerateLorem("Paragraphs(2)");

            Assert.AreNotEqual(result.IndexOf("\n"), 0);
            Assert.Greater(result.Length, 1);
        }

        [Test]
        public void TestShouldGenerateEmptyLoremForInvalidToken()
        {
            string result = _tokenService.GenerateLorem("fdasfla");

            Assert.AreEqual(result, null);
        }

        [Test]
        public void TestShouldGenerateRandomNumber()
        {
            string result = _tokenService.GenerateNumber("RandomNumber");

            Assert.IsTrue(int.TryParse(result, out _));
        }

        [Test]
        public void TestShouldGenerateRandomNumberMax()
        {
            string result = _tokenService.GenerateNumber("RandomNumberMax(10)");
            int number;

            Assert.IsTrue(int.TryParse(result, out number));
            Assert.LessOrEqual(number, 10);
        }

        [Test]
        public void TestShouldGenerateRandomNumberMinMax()
        {
            string result = _tokenService.GenerateNumber("RandomNumberMinMax(2, 10)");
            int number;

            Assert.IsTrue(int.TryParse(result, out number));
            Assert.LessOrEqual(number, 10);
            Assert.GreaterOrEqual(number, 2);
        }

        [Test]
        public void TestShouldGenerateEmptyRandomNumberForInvalidToken()
        {
            string result = _tokenService.GenerateNumber("RandomNumberMinMax(2, 10, 11)");

            Assert.AreEqual(result, null);
        }

        [Test]
        public void TestShouldGenerateId()
        {
            string result = _tokenService.GeneratePerson("Id");

            Assert.IsTrue(Guid.TryParse(result, out _));
        }

        [Test]
        public void TestShouldGenerateFullName()
        {
            string result = _tokenService.GeneratePerson("FullName");

            Assert.AreNotEqual(result.IndexOf(' '), 0);
            Assert.Greater(result.Length, 1);
        }

        [Test]
        public void TestShouldGenerateFirstName()
        {
            string result = _tokenService.GeneratePerson("FirstName");

            Assert.Greater(result.Length, 1);
        }

        [Test]
        public void TestShouldGenerateLastName()
        {
            string result = _tokenService.GeneratePerson("LastName");

            Assert.Greater(result.Length, 1);
        }

        [Test]
        public void TestShouldGeneratePersonPrefix()
        {
            string result = _tokenService.GeneratePerson("PersonPrefix");

            Assert.Greater(result.Length, 1);
        }

        [Test]
        public void TestShouldGeneratePersonSuffix()
        {
            string result = _tokenService.GeneratePerson("PersonSuffix");

            Assert.Greater(result.Length, 0);
        }

        [Test]
        public void TestShouldGeneratePhoneNumber()
        {
            string result = _tokenService.GeneratePerson("PhoneNumber");

            Assert.Greater(result.Length, 1);
            Assert.IsTrue(Regex.Match(result, @"\d+").Success);
        }

        [Test]
        public void TestShouldGenerateCountry()
        {
            string result = _tokenService.GeneratePerson("Country");

            Assert.Greater(result.Length, 1);
        }

        [Test]
        public void TestShouldGenerateZipCode()
        {
            string result = _tokenService.GeneratePerson("ZipCode");

            Assert.Greater(result.Length, 1);
        }

        [Test]
        public void TestShouldGenerateUsState()
        {
            string result = _tokenService.GeneratePerson("UsState");

            Assert.Greater(result.Length, 2);
        }

        [Test]
        public void TestShouldGenerateUsStateAbbr()
        {
            string result = _tokenService.GeneratePerson("UsStateAbbr");

            Assert.Greater(result.Length, 1);
        }

        [Test]
        public void TestShouldGenerateCityPrefix()
        {
            string result = _tokenService.GeneratePerson("CityPrefix");

            Assert.Greater(result.Length, 1);
        }

        [Test]
        public void TestShouldGenerateCitySufix()
        {
            string result = _tokenService.GeneratePerson("CitySufix");

            Assert.Greater(result.Length, 1);
        }

        [Test]
        public void TestShouldGenerateCity()
        {
            string result = _tokenService.GeneratePerson("City");

            Assert.Greater(result.Length, 2);
        }

        [Test]
        public void TestShouldGenerateStreetSuffix()
        {
            string result = _tokenService.GeneratePerson("StreetSuffix");

            Assert.Greater(result.Length, 2);
        }

        [Test]
        public void TestShouldGenerateStreetName()
        {
            string result = _tokenService.GeneratePerson("StreetName");

            Assert.Greater(result.Length, 2);
        }

        [Test]
        public void TestShouldGenerateStreetAddress()
        {
            string result = _tokenService.GeneratePerson("StreetAddress");

            Assert.Greater(result.Length, 2);
        }

        [Test]
        public void TestShouldGenerateSecondaryAddress()
        {
            string result = _tokenService.GeneratePerson("SecondaryAddress");

            Assert.Greater(result.Length, 2);
        }

        [Test]
        public void TestShouldGenerateUkCounty()
        {
            string result = _tokenService.GeneratePerson("UkCounty");

            Assert.Greater(result.Length, 2);
        }

        [Test]
        public void TestShouldGenerateUkPostCode()
        {
            string result = _tokenService.GeneratePerson("UkPostCode");

            Assert.Greater(result.Length, 2);
        }

        [Test]
        public void TestShouldGenerateEmail()
        {
            string result = _tokenService.GeneratePerson("Email");

            Assert.Greater(result.Length, 2);
            Assert.AreNotEqual(result.IndexOf('@'), 0);
        }

        [Test]
        public void TestShouldGenerateFreeEmail()
        {
            string result = _tokenService.GeneratePerson("FreeEmail");

            Assert.Greater(result.Length, 2);
            Assert.AreNotEqual(result.IndexOf('@'), 0);
        }

        [Test]
        public void TestShouldGenerateUserName()
        {
            string result = _tokenService.GeneratePerson("UserName");

            Assert.Greater(result.Length, 2);
        }

        [Test]
        public void TestShouldGenerateEmptyPersonForInvalidToken()
        {
            string result = _tokenService.GeneratePerson("111");

            Assert.AreEqual(result, null);
        }

        [Test]
        public void TestShouldGenerateCompanyName()
        {
            string result = _tokenService.GenerateCompany("CompanyName");

            Assert.Greater(result.Length, 2);
        }

        [Test]
        public void TestShouldGenerateCompanySuffix()
        {
            string result = _tokenService.GenerateCompany("CompanySuffix");

            Assert.Greater(result.Length, 1);
        }

        [Test]
        public void TestShouldGenerateCompanyCatchPhrase()
        {
            string result = _tokenService.GenerateCompany("CompanyCatchPhrase");

            Assert.Greater(result.Length, 2);
        }

        [Test]
        public void TestShouldGenerateCompanyBS()
        {
            string result = _tokenService.GenerateCompany("CompanyBS");

            Assert.Greater(result.Length, 2);
        }

        [Test]
        public void TestShouldGenerateDomainName()
        {
            string result = _tokenService.GenerateCompany("DomainName");

            Assert.Greater(result.Length, 2);
            Assert.AreNotEqual(result.IndexOf('.'), -1);
        }

        [Test]
        public void TestShouldGenerateDomainWord()
        {
            string result = _tokenService.GenerateCompany("DomainWord");

            Assert.Greater(result.Length, 2);
        }

        [Test]
        public void TestShouldGenerateDomainSuffix()
        {
            string result = _tokenService.GenerateCompany("DomainSuffix");

            Assert.Greater(result.Length, 1);
        }

        [Test]
        public void TestShouldGenerateEmptyCompanyForInvalidToken()
        {
            string result = _tokenService.GenerateCompany("Company22");

            Assert.AreEqual(result, null);
        }

    }
}