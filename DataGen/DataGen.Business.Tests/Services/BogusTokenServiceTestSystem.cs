using System;
using NUnit.Framework;
using System.Text.RegularExpressions;

namespace DataGen.Business.Tests.Services
{
    partial class BogusTokenServiceTest
    {
        // Column
        [Test]
        public void TestShouldGetColumn()
        {
            var result = _tokenService.GetSystem("Column");
            Assert.GreaterOrEqual(result.Length, 1);
        }

        // DataType
        [Test]
        public void TestShouldGetDataType()
        {
            var result = _tokenService.GetSystem("DataType");
            Assert.GreaterOrEqual(result.Length, 3);
        }

        // Collation
        [Test]
        public void TestShouldGetCollation()
        {
            var result = _tokenService.GetSystem("Collation");
            Assert.GreaterOrEqual(result.Length, 3);
        }

        // DatabaseEngine
        [Test]
        public void TestShouldGetDatabaseEngine()
        {
            var result = _tokenService.GetSystem("DatabaseEngine");
            Assert.GreaterOrEqual(result.Length, 3);
        }

        // FileName
        [Test]
        public void TestShouldGetFileName()
        {
            var result = _tokenService.GetSystem("FileName");
            Assert.GreaterOrEqual(result.Length, 3);
            Assert.Greater(result.IndexOf('.'), 0); // has extension
        }

        // DirectoryPath
        [Test]
        public void TestShouldGetDirectoryPath()
        {
            var result = _tokenService.GetSystem("DirectoryPath");
            Assert.GreaterOrEqual(result.Length, 3);
        }

        // FilePath
        [Test]
        public void TestShouldGetFilePath()
        {
            var result = _tokenService.GetSystem("FilePath");
            Assert.GreaterOrEqual(result.Length, 3);
        }

        // MimeType
        [Test]
        public void TestShouldGetMimeType()
        {
            var result = _tokenService.GetSystem("MimeType");
            Assert.GreaterOrEqual(result.Length, 1);
        }

        // CommonFileType
        [Test]
        public void TestShouldGetCommonFileType()
        {
            var result = _tokenService.GetSystem("CommonFileType");
            Assert.GreaterOrEqual(result.Length, 1);
        }

        // CommonFileExt
        [Test]
        public void TestShouldGetCommonFileExt()
        {
            var result = _tokenService.GetSystem("CommonFileExt");
            Assert.GreaterOrEqual(result.Length, 1);
        }

        // FileType
        [Test]
        public void TestShouldGetFileType()
        {
            var result = _tokenService.GetSystem("FileType");
            Assert.GreaterOrEqual(result.Length, 1);
        }

        // FileExt
        [Test]
        public void TestShouldGetFileExt()
        {
            var result = _tokenService.GetSystem("FileExt");
            Assert.GreaterOrEqual(result.Length, 1);
        }

        // Semver
        [Test]
        public void TestShouldGetSemver()
        {
            var result = _tokenService.GetSystem("Semver");
            Assert.GreaterOrEqual(result.Length, 1);
            Assert.Greater(result.IndexOf('.'), 0);
        }

        // Version
        [Test]
        public void TestShouldGetVersion()
        {
            var result = _tokenService.GetSystem("Version");
            Assert.GreaterOrEqual(result.Length, 1);
        }

        // Exception
        [Test]
        public void TestShouldGetException()
        {
            var result = _tokenService.GetSystem("Exception");
            Assert.GreaterOrEqual(result.Length, 1);
        }

        // AndroidId
        [Test]
        public void TestShouldGetAndroidId()
        {
            var result = _tokenService.GetSystem("AndroidId");
            Assert.GreaterOrEqual(result.Length, 3);
        }

        // ApplePushToken
        [Test]
        public void TestShouldGetApplePushToken()
        {
            var result = _tokenService.GetSystem("ApplePushToken");
            Assert.GreaterOrEqual(result.Length, 3);
        }

        // BlackBerryPin
        [Test]
        public void TestShouldGetBlackBerryPin()
        {
            var result = _tokenService.GetSystem("BlackBerryPin");
            Assert.GreaterOrEqual(result.Length, 3);
        }

        [Test]
        public void TestShouldGetRandomNumber()
        {
            var result = _tokenService.GetSystem("Number");
            Assert.IsTrue(int.TryParse(result, out _));
        }

        // Number(max)
        [Test]
        public void TestShouldGetRandomNumberFromMin()
        {
            var result = _tokenService.GetSystem("Number(10)");
            Assert.IsTrue(int.TryParse(result, out int num));
            Assert.LessOrEqual(num, 10);
        }

        // Number(min, max)
        [Test]
        public void TestShouldGetRandomNumberWithinMinMax()
        {
            var result = _tokenService.GetSystem("Number(5, 20)");
            Assert.IsTrue(int.TryParse(result, out int num));
            Assert.LessOrEqual(num, 20);
            Assert.GreaterOrEqual(num, 5);
        }

        // Digits(length)
        [Test]
        public void TestShouldGetRandomDigits()
        {
            var digitCount = 10;
            var commaCount = digitCount - 1;
            var result = _tokenService.GetSystem($"Digits({digitCount})");
            Assert.AreEqual(result.Length, digitCount + commaCount);
        }

        // Even
        [Test]
        public void TestShouldGetRandomEven()
        {
            var result = _tokenService.GetSystem("Even");
            Assert.IsTrue(int.TryParse(result, out int num));
            Assert.AreEqual(num % 2, 0);
        }

        // Even(min)
        [Test]
        public void TestShouldGetRandomEvenFromMin()
        {
            var result = _tokenService.GetSystem("Even(2)");
            Assert.IsTrue(int.TryParse(result, out int num));
            Assert.GreaterOrEqual(num, 2);
            Assert.AreEqual(num % 2, 0);
        }

        // Even(min, max)
        [Test]
        public void TestShouldGetRandomEvenWithinMinMax()
        {
            var result = _tokenService.GetSystem("Even(3, 7)");
            Assert.IsTrue(int.TryParse(result, out int num));
            Assert.LessOrEqual(num, 7);
            Assert.GreaterOrEqual(num, 3);
            Assert.AreEqual(num % 2, 0);
        }

        // Odd
        [Test]
        public void TestShouldGetRandomOdd()
        {
            var result = _tokenService.GetSystem("Odd");
            Assert.IsTrue(int.TryParse(result, out int num));
            Assert.AreNotEqual(num % 2, 0);
        }

        // Odd(min)
        [Test]
        public void TestShouldGetRandomOddFromMin()
        {
            var result = _tokenService.GetSystem("Odd(5)");
            Assert.IsTrue(int.TryParse(result, out int num));
            Assert.GreaterOrEqual(num, 5);
            Assert.AreNotEqual(num % 2, 0);
        }

        // Odd(min, max)
        [Test]
        public void TestShouldGetRandomOddWithinMinMax()
        {
            var result = _tokenService.GetSystem("Odd(3, 17)");
            Assert.IsTrue(int.TryParse(result, out int num));
            Assert.LessOrEqual(num, 17);
            Assert.GreaterOrEqual(num, 3);
            Assert.AreNotEqual(num % 2, 0);
        }

        // Double
        [Test]
        public void TestShouldGetRandomDouble()
        {
            var result = _tokenService.GetSystem("Double");
            Assert.IsTrue(double.TryParse(result, out _));
        }

        // Double(min)
        [Test]
        public void TestShouldGetRandomDoubleMin()
        {
            var result = _tokenService.GetSystem("Double(4)");
            Assert.IsTrue(double.TryParse(result, out double num));
            Assert.GreaterOrEqual(num, 4);
        }

        // Double(min, max)
        [Test]
        public void TestShouldGetRandomDoubleWithinMinMax()
        {
            var result = _tokenService.GetSystem("Double(5, 10)");
            Assert.IsTrue(double.TryParse(result, out double num));
            Assert.GreaterOrEqual(num, 5);
            Assert.LessOrEqual(num, 10);
        }

        // Decimal
        [Test]
        public void TestShouldGetRandomDecimal()
        {
            var result = _tokenService.GetSystem("Decimal");
            Assert.IsTrue(decimal.TryParse(result, out _));
        }

        // Decimal(min)
        [Test]
        public void TestShouldGetRandomDecimalMin()
        {
            var result = _tokenService.GetSystem("Decimal(5)");
            Assert.IsTrue(decimal.TryParse(result, out decimal num));
            Assert.GreaterOrEqual(num, 5);
        }

        // Decimal(min, max)
        [Test]
        public void TestShouldGetRandomDecimalWithinMinMax()
        {
            var result = _tokenService.GetSystem("Decimal(5, 10)");
            Assert.IsTrue(decimal.TryParse(result, out decimal num));
            Assert.GreaterOrEqual(num, 5);
            Assert.LessOrEqual(num, 10);
        }

        // Float
        [Test]
        public void TestShouldGetRandomFloat()
        {
            var result = _tokenService.GetSystem("Float");
            Assert.IsTrue(float.TryParse(result, out _));
        }

        // Float(min)
        [Test]
        public void TestShouldGetRandomFloatMin()
        {
            var result = _tokenService.GetSystem("Float(5)");
            Assert.IsTrue(float.TryParse(result, out float num));
            Assert.GreaterOrEqual(num, 5);
        }

        // Float(min, max)
        [Test]
        public void TestShouldGetRandomFloatWithinMinMax()
        {
            var result = _tokenService.GetSystem("Float(5, 10)");
            Assert.IsTrue(float.TryParse(result, out float num));
            Assert.GreaterOrEqual(num, 5);
            Assert.LessOrEqual(num, 10);
        }

        // Int
        [Test]
        public void TestShouldGetRandomInt()
        {
            var result = _tokenService.GetSystem("Int");
            Assert.IsTrue(int.TryParse(result, out _));
        }

        // Int(min)
        [Test]
        public void TestShouldGetRandomIntMin()
        {
            var result = _tokenService.GetSystem("Int(5)");
            Assert.IsTrue(int.TryParse(result, out int num));
            Assert.GreaterOrEqual(num, 5);
        }

        // Int(min, max)
        [Test]
        public void TestShouldGetRandomIntWithinMinMax()
        {
            var result = _tokenService.GetSystem("Int(5, 10)");
            Assert.IsTrue(int.TryParse(result, out int num));
            Assert.GreaterOrEqual(num, 5);
            Assert.LessOrEqual(num, 10);
        }

        // Long
        [Test]
        public void TestShouldGetRandomLong()
        {
            var result = _tokenService.GetSystem("Long");
            Assert.IsTrue(long.TryParse(result, out _));
        }

        // Long
        [Test]
        public void TestShouldGetRandomLongFromMin()
        {
            var result = _tokenService.GetSystem("Long(-100)");
            Assert.IsTrue(long.TryParse(result, out long num));
            Assert.GreaterOrEqual(num, -100);
        }

        // Long
        [Test]
        public void TestShouldGetRandomLongWithinMinMax()
        {
            var result = _tokenService.GetSystem("Long(5,  100)");
            Assert.IsTrue(long.TryParse(result, out long num));
            Assert.GreaterOrEqual(num, 5);
            Assert.LessOrEqual(num, 100);
        }

        // Char
        [Test]
        public void TestShouldGetRandomChar()
        {
            var result = _tokenService.GetSystem("Char");
            Assert.AreEqual(result.Length, 1);
        }

        // String
        [Test]
        public void TestShouldGetRandomString()
        {
            var result = _tokenService.GetSystem("String");
            Assert.GreaterOrEqual(result.Length, 1);
        }

        // String(length)
        [Test]
        public void TestShouldGetRandomStringWithLength()
        {
            var result = _tokenService.GetSystem("String(5)");
            Assert.AreEqual(result.Length, 5);
        }

        // Hash
        [Test]
        public void TestShouldGetRandomHash()
        {
            var result = _tokenService.GetSystem("Hash");
            Assert.GreaterOrEqual(result.Length, 3);
        }

        // Hash(length)
        [Test]
        public void TestShouldGetRandomHashWithLength()
        {
            var result = _tokenService.GetSystem("Hash(10)");
            Assert.AreEqual(result.Length, 10);
        }

        // Bool
        [Test]
        public void TestShouldGetRandomBool()
        {
            var result = _tokenService.GetSystem("Bool");
            Assert.Contains(result, new string[]
            {
                "True",
                "False"
            });
        }

        // Guid
        [Test]
        public void TestShouldGetRandomGuid()
        {
            var result = _tokenService.GetSystem("Guid");
            Assert.GreaterOrEqual(result.Length, 16);
        }

        // Uuid
        [Test]
        public void TestShouldGetRandomUuid()
        {
            var result = _tokenService.GetSystem("Uuid");
            Assert.GreaterOrEqual(result.Length, 16);
        }

        // RandomLocale
        [Test]
        public void TestShouldGetRandomRandomLocale()
        {
            var result = _tokenService.GetSystem("RandomLocale");
            Assert.GreaterOrEqual(result.Length, 2);
        }

        // AlphaNumeric(length)
        [Test]
        public void TestShouldGetRandomAlphaNumericWithLength()
        {
            var result = _tokenService.GetSystem("AlphaNumeric(10)");
            Assert.GreaterOrEqual(result.Length, 10);
            Assert.IsTrue(Regex.Match(result, AlphaNumbericPattern).Success);
        }

        // Hexadecimal
        [Test]
        public void TestShouldGetRandomHexadecimal()
        {
            var result = _tokenService.GetSystem("Hexadecimal");
            Assert.IsTrue(Regex.Match(result, HexadecimalPattern).Success);
        }

        // Hexadecimal(length)
        [Test]
        public void TestShouldGetRandomHexadecimalWithLength()
        {
            var result = _tokenService.GetSystem("Hexadecimal(9)");
            Assert.GreaterOrEqual(result.Length, 9);
            Assert.IsTrue(Regex.Match(result, HexadecimalPattern).Success);
        }

        // Word
        [Test]
        public void TestShouldGetRandomWord()
        {
            var result = _tokenService.GetSystem("Word");
            Assert.GreaterOrEqual(result.Length, 1);
        }

        // Words
        [Test]
        public void TestShouldGetRandomWords()
        {
            var result = _tokenService.GetSystem("Words");
            Assert.GreaterOrEqual(result.Length, 3);
        }

        // Words(count)
        [Test]
        public void TestShouldGetRandomWordsWithProvidedCount()
        {
            var result = _tokenService.GetSystem("Words(3)");
            Assert.GreaterOrEqual(result.Length, 3);
            Assert.GreaterOrEqual(result.Split(" ").Length, 3);
        }

        // ArrayElement(value1, value2, ...)
        [Test]
        public void TestShouldGetRandomArrayElement()
        {
            var result = _tokenService.GetSystem("ArrayElement(a, b)");
            Assert.Contains(result, new string[]
            {
                "",
                "a",
                "b"
            });
        }

        // ArrayElements(value1, value2, ...)
        [Test]
        public void TestShouldGetRandomArrayElements()
        {
            var result = _tokenService.GetSystem("ArrayElements(a, b, c)");
            Assert.Contains(result, new string[]
            {
                "",
                "a",
                "b",
                "c"
            });
        }

        // Past(format)
        [Test]
        public void TestShouldGetRandomPastDateByDateFormat()
        {
            var format = "yyyy-MM-dd";
            var result = _tokenService.GetSystem($"Past({format})");
            Assert.Greater(result.Length, 3);
            Assert.Less(DateTime.Parse(result), DateTime.Now);
        }

        // Soon(format)
        [Test]
        public void TestShouldGetRandomSoonDateByDateFormat()
        {
            var format = "yyyy-MM-dd";
            var result = _tokenService.GetSystem($"Soon({format})");
            Assert.Greater(result.Length, 3);
            Assert.Less(DateTime.Parse(result), DateTime.Now);
        }

        // Future(format)
        [Test]
        public void TestShouldGetRandomFutureDateByDateFormat()
        {
            var format = "yyyy-MM-dd";
            var result = _tokenService.GetSystem($"Future({format})");
            Assert.Greater(result.Length, 3);
            Assert.Less(DateTime.Parse(result), DateTime.Now);
        }

        // Between(format)
        [Test]
        public void TestShouldGetRandomBetweenDateByDateFormat()
        {
            var result = _tokenService.GetSystem($"Between({format})");
        }

        // Recent(format)
        [Test]
        public void TestShouldGetRandomRecentDateByDateFormat()
        {
            var result = _tokenService.GetSystem($"Recent({format})");
        }

        // Timespan(format)
        [Test]
        public void TestShouldGetRandomTimespanDateByDateFormat()
        {
            var result = _tokenService.GetSystem($"Timespan({format})");
        }

        // Month(format)
        [Test]
        public void TestShouldGetRandomMonthDateByDateFormat()
        {
            var result = _tokenService.GetSystem($"Month({format})");
        }

        // Weekday(format)
        [Test]
        public void TestShouldGetRandomWeekdayDateByDateFormat()
        {
            var result = _tokenService.GetSystem($"Weekday({format})");
        }
    }
}
