using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOSE.TDD.StringCalculator
{
    public class NumberStringParser
    {
        public const string Seperator = ",";

        public List<int> Parse(string listWithNumbersToParse)
        {
            List<int> parsedNumbers = new List<int>();
            if (ValidateInputNotEmpty(listWithNumbersToParse))
            {
                return parsedNumbers;
            } 

            var stringParts = listWithNumbersToParse.Split(Seperator);
            foreach (var part in stringParts)
            {
                parsedNumbers.Add(int.Parse(part));
            }
            return parsedNumbers;
        }

        private bool ValidateInputNotEmpty(string input)
        {
            return string.IsNullOrEmpty(input);
        }
    }
}
