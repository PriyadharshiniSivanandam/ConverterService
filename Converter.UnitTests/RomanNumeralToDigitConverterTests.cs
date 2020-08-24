using ConverterService.ApplicationServices;
using ConverterService.ApplicationServices.Exceptions;
using NUnit.Framework;

namespace ConverterService.UnitTests
{
    public class RomanNumeralToDigitConverterTests
    {

        [TestCase("I", 1)]
        [TestCase("IV", 4)]
        [TestCase("IX", 9)]
        [TestCase("XC", 90)]
        [TestCase("CM", 900)]
        [TestCase("MCMIII", 1903)]
        [TestCase( "MCMXCVII", 1997)]
        public void ConverterTest_RomanNumeral_Digit(string input, int expectedOutput)
        {
            var converter = new RomanNumeralToDigitConverter();

            var actualOutput = converter.Convert(input);

            Assert.AreEqual(expectedOutput, actualOutput);
        }

        [TestCase("FGM")]
        [TestCase("MMMMM")]
        public void ConverterTest_InvalidRomanNumeral_InvalidInputException(string input)
        {
            var converter = new RomanNumeralToDigitConverter();

            Assert.Throws<InvalidInputException>(() => converter.Convert(input));
        }
    }
}
