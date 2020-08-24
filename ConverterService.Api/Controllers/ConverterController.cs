using ConverterService.ApplicationServices;
using ConverterService.ApplicationServices.Exceptions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ConverterService.Api.Controllers
{
    [Route("api/convert")]
    [ApiController]
    public class ConverterController : ControllerBase
    {
        private readonly DigitToRomanNumeralConverter _digitToRomanNumeralConverter;
        private readonly RomanNumeralToDigitConverter _romanNumeralToDigitConverter;

        public ConverterController(DigitToRomanNumeralConverter digitToRomanNumeralConverter, RomanNumeralToDigitConverter romanNumeralToDigitConverter)
        {
            _digitToRomanNumeralConverter = digitToRomanNumeralConverter;
            _romanNumeralToDigitConverter = romanNumeralToDigitConverter;
        }

        /// <summary>
        /// Convert the given digit into a roman numeral
        /// </summary>
        /// <param name="input">The digit that needs to be converted</param>
        /// <response code="200">Returns the converted roman numeral</response>
        /// <response code="400">If the input is not valid</response>
        [HttpPost("digit/to/romanNumeral/{input}")]
        [ProducesResponseType(typeof(string), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult ConvertDigitToRomanNumeral(string input)
        {
            try
            {
                var romanNumeral = _digitToRomanNumeralConverter.Convert(input);
                return Ok(romanNumeral);
            }
            catch (InvalidInputException exception)
            {
                return BadRequest(exception.Message);
            }
        }

        /// <summary>
        /// Convert the given roman numeral into a digit
        /// </summary>
        /// <param name="input">The roman numeral that needs to be converted</param>
        /// <response code="200">Returns the converted digit</response>
        /// <response code="400">If the input is not valid</response>
        [HttpPost("romanNumeral/to/digit/{input}")]
        [ProducesResponseType(typeof(int), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult ConvertRomanNumeralToDigit(string input)
        {
            try
            {
                var digit = _romanNumeralToDigitConverter.Convert(input);
                return Ok(digit);
            }
            catch (InvalidInputException exception)
            {
                return BadRequest(exception.Message);
            }
        }
    }
}
