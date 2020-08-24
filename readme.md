# ConverterService

## Requirements

Provide a REST API server that can convert digits to numerals and numerals to digits.

## Api Url

https://localhost:5003

## Description

The service offers two separate API's for the conversion.

Route for DigitsToRomanNumerals conversion: https://localhost:5003/api/convert/digits/to/romanNumerals/input, in which 'input' is the value of digits that needs to be converted.

Route for RomanNumeralsToDigits conversion: https://localhost:5003/api/convert/romanNumerals/to/digits/input, in which 'input' is the value of romanNumeral that needs to be converted.

DigitsToRomanNumerals Conversion:

Example:https://localhost:5003/api/convert/digits/to/romanNumerals/1992

Considering that romanNumerals are valid from only 1 to 3999 error cases has been handled for 0, negative values and values greater than 3999.

RomanNumeralsToDigits Conversion:

Example:https://localhost:5003/api/convert/romanNumerals/to/digits/XVI

Considering that romanNumerals can have only the following characters {I,V,X,L,C,D,M} error case has been handled for invalid characters.

Test Cases:

Conversion has been tested for 1,4,9,90,900,1903,1997,4000,0,-1.

Features: Follows SOLID Principle Unit Tested

## Api Documentation

Detailed route documentation can be found in the https://localhost:5003/.docs
