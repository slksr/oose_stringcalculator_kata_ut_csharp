using System;

namespace OOSE.TDD.StringCalculator
{
    public class Calculator
    {


        public int Add(string numberString)
        {
            NumberStringParser parser = new NumberStringParser();
            var parsedNumers = parser.Parse(numberString);
            return parsedNumers.Sum();
        }
    }
}