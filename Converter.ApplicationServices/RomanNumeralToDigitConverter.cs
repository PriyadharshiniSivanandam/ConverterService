using ConverterService.ApplicationServices.Exceptions;

namespace ConverterService.ApplicationServices
{
    public class RomanNumeralToDigitConverter
    {
        public int Convert(string roman)
        {
            var digit = 0;
            for (int i = 0; i < roman.Length; i++)
            {
                if (i + 1 < roman.Length && RomanToDigitMap(roman[i]) < RomanToDigitMap(roman[i + 1]))
                {
                    digit -= RomanToDigitMap(roman[i]);
                }
                else
                {
                    digit += RomanToDigitMap(roman[i]);
                }
            }

            if (digit >= 4000)
            {
                throw new InvalidInputException($"The converted digit is '{digit}' but the roman numeral can only be formed for digits from 1 to 3999");
            }
            return digit;
        }

        private static int RomanToDigitMap(char index)
        {
            return index switch
            {
                'I' => 1,
                'V' => 5,
                'X' => 10,
                'L' => 50,
                'C' => 100,
                'D' => 500,
                'M' => 1000,
                _ => throw new InvalidInputException("Roman numerals can only be formed from {I,V,X,L,C,D,M}")
            };
        }

    }
}
