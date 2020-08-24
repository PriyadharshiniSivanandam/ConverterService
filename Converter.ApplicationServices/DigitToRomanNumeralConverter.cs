using ConverterService.ApplicationServices.Exceptions;

namespace ConverterService.ApplicationServices
{
    public class DigitToRomanNumeralConverter
    {
        public string Convert(string digit)
        {
            string romanNumeral = "";

            if(System.Convert.ToInt32(digit) <= 0)
                throw new InvalidInputException("Digits greater than 0 can only be converted to Roman numerals.");

            if (System.Convert.ToInt32(digit) >= 4000)
                throw new InvalidInputException("The biggest digit we can form in Roman numerals is 3999.");

            for (int i = 0; i < digit.Length; i++)
            {
                var index = 2 * (digit.Length - (i + 1)) + 1;

                var roman1 = DigitToRomanMap(index);
                var roman2 = DigitToRomanMap(index + 1);
                var roman3 = DigitToRomanMap(index + 2);

                var originalValue = System.Convert.ToInt32(digit[i] - '0');

                switch (originalValue)
                {
                    case 1:
                    case 2:
                    case 3:
                        for (int j = 0; j < originalValue; j++)
                            romanNumeral += roman1.ToString();
                        break;
                    case 4:
                        romanNumeral += roman1.ToString()+ roman2.ToString();
                        break;
                    case 5:
                        romanNumeral += roman2.ToString();
                        break;
                    case 6:
                    case 7:
                    case 8:
                        romanNumeral += roman2.ToString();
                        for (int j = 0; j < originalValue - 5; j++)
                            romanNumeral += roman1.ToString();
                        break;
                    case 9:
                        romanNumeral += roman1.ToString() + roman3.ToString();
                        break;
                }
            }

            return romanNumeral;
        }

        private static char DigitToRomanMap(int index)
        {
            return index switch
            {
                1 => 'I',
                2 => 'V',
                3 => 'X',
                4 => 'L',
                5 => 'C',
                6 => 'D',
                7 => 'M',
                _ => ' '
            };
        }
    }
}
