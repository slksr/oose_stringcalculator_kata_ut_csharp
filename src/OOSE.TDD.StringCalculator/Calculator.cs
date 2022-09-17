using System;

namespace OOSE.TDD.StringCalculator
{
    public class Calculator
    {
        public const string Seperator = ",";

        public int Add(string numberString)
        {
            if (string.IsNullOrEmpty(numberString))
            {
                return 0;
            }
            else if (numberString.Length == 1) 
            {
                return int.Parse(numberString);
            }
            else
            {
                var stringParts = numberString.Split(Seperator);
                return int.Parse(stringParts[0]) + int.Parse(stringParts[1]);
            }
        }
    }
}