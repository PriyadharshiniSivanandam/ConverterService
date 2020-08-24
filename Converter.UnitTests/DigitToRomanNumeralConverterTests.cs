using ConverterService.ApplicationServices;
using ConverterService.ApplicationServices.Exceptions;
using NUnit.Framework;

namespace ConverterService.UnitTests
{
    public class DigitToRomanNumeralConverterTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [TestCase("1", "I")]
        [TestCase("4", "IV")]
        [TestCase("9", "IX")]
        [TestCase("90", "XC")]
        [TestCase("900", "CM")]
        [TestCase("1903", "MCMIII")]
        [TestCase("1997", "MCMXCVII")]
        public void ConverterTest_Digit_RomanNumeral(string input, string expectedOutput)
        {
            var converter = new DigitToRomanNumeralConverter();

            var actualOutput = converter.Convert(input);

            Assert.AreEqual(expectedOutput, actualOutput);
        }

        [TestCase("0")]
        [TestCase("-1")]
        [TestCase("4000")]
        public void ConverterTest_InvalidInput_InvalidInputException(string input)
        {
            var converter = new DigitToRomanNumeralConverter();

            Assert.Throws<InvalidInputException>(() => converter.Convert(input));
        }
    }
}