using System;

namespace OOSE.TDD.StringCalculator
{
    public class Calculator
    {
        private NumberStringParser parser = new NumberStringParser();

        public int Add(string numberString)
        {
            var parsedNumers = parser.Parse(numberString);
            return parsedNumers.Sum();
        }
    }
}