using System;

namespace OOSE.TDD.StringCalculator
{
    public class Calculator
    {
        

        public int Add(string numberString)
        {
            NumberStringParser parser = new NumberStringParser(numberString);
            var parsedNumers = parser.Parse();
            return parsedNumers.Sum();
        }
    }
}