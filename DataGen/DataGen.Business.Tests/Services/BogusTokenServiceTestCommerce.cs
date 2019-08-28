using NUnit.Framework;
using System;

namespace DataGen.Business.Tests.Services
{
    partial class BogusTokenServiceTest
    {
        // Department
        [Test]
        public void TestShouldGetDepartment()
        {
            var result = _tokenService.GetCommerce("Department");
            Assert.GreaterOrEqual(result.Length, 3);
        }

        // Price
        [Test]
        public void TestShouldGetPrice()
        {
            var result = _tokenService.GetCommerce("Price");
            Assert.GreaterOrEqual(result.Length, 3);
        }

        // Categories
        [Test]
        public void TestShouldGetCategories()
        {
            var result = _tokenService.GetCommerce("Categories");
            Assert.GreaterOrEqual(result.Length, 3);
            Assert.AreEqual(result.IndexOf('['), 0);
        }

        // ProductName
        [Test]
        public void TestShouldGetProductName()
        {
            var result = _tokenService.GetCommerce("ProductName");
            Assert.GreaterOrEqual(result.Length, 3);
        }

        // Color
        [Test]
        public void TestShouldGetColor()
        {
            var result = _tokenService.GetCommerce("Color");
            Assert.GreaterOrEqual(result.Length, 3);
        }

        // Product
        [Test]
        public void TestShouldGetProduct()
        {
            var result = _tokenService.GetCommerce("Product");
            Assert.GreaterOrEqual(result.Length, 3);
        }

        // ProductAdjective
        [Test]
        public void TestShouldGetProductAdjective()
        {
            var result = _tokenService.GetCommerce("ProductAdjective");
            Assert.GreaterOrEqual(result.Length, 3);
        }

        // ProductMaterial
        [Test]
        public void TestShouldGetProductMaterial()
        {
            var result = _tokenService.GetCommerce("ProductMaterial");
            Assert.GreaterOrEqual(result.Length, 3);
        }

        // Ean8
        [Test]
        public void TestShouldGetEan8()
        {
            var result = _tokenService.GetCommerce("Ean8");
            Assert.GreaterOrEqual(result.Length, 3);
        }

        // Ean13
        [Test]
        public void TestShouldGetEan13()
        {
            var result = _tokenService.GetCommerce("Ean13");
            Assert.GreaterOrEqual(result.Length, 3);
        }

        // CompanySuffix
        [Test]
        public void TestShouldGetCompanySuffix()
        {
            var result = _tokenService.GetCommerce("CompanySuffix");
            Assert.GreaterOrEqual(result.Length, 2);
        }

        // CompanyName
        [Test]
        public void TestShouldGetCompanyName()
        {
            var result = _tokenService.GetCommerce("CompanyName");
            Assert.GreaterOrEqual(result.Length, 3);
        }

        // CompanyCatchPhrase
        [Test]
        public void TestShouldGetCompanyCatchPhrase()
        {
            var result = _tokenService.GetCommerce("CompanyCatchPhrase");
            Assert.GreaterOrEqual(result.Length, 3);
        }

        // CompanyBs
        [Test]
        public void TestShouldGetCompanyBs()
        {
            var result = _tokenService.GetCommerce("CompanyBs");
            Assert.GreaterOrEqual(result.Length, 1);
        }
    }
}
