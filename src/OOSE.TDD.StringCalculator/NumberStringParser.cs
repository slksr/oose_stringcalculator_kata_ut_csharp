using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOSE.TDD.StringCalculator
{
    public class NumberStringParser
    {
        private string listWithNumbersToParse;
        private char[] separators = { ',', '\n' };

        public NumberStringParser(string listWithNumbersToParse)
        {
            this.listWithNumbersToParse = listWithNumbersToParse;
        }

        public List<int> Parse()
        {
            if (PrefixedWithDifferentSeparator(listWithNumbersToParse))
            {
                separators[0] = char.Parse(listWithNumbersToParse.Substring(2, 1));
                StripPrefixedSeparator();
            }
            return ParseWithSeparators(listWithNumbersToParse);
        }

        private List<int> ParseWithSeparators(string listWithNumbersToParse)
        {
            string errorText = "Niet toegestane tekens in de lijst met cijfers.";
            List<int> parsedNumbers = new();

            var tokens = listWithNumbersToParse.Split(separators);

            if (tokens.Length == 1)
            {
                if (SeparatorsAreNotUsedAsDelimiters(listWithNumbersToParse))
                {
                    throw new ArgumentException(errorText);
                }
                else if (ValidateInputNotEmpty(listWithNumbersToParse))
                {
                    return parsedNumbers;
                }
                else
                {
                    parsedNumbers.Add(int.Parse(tokens[0]));
                    return parsedNumbers;
                }
            }
            

            foreach (var part in tokens)
            {
                if (!int.TryParse(part, out int number))
                {
                    throw new ArgumentException(errorText);
                }
                parsedNumbers.Add(number);
            }
            return parsedNumbers;
        }

        private void StripPrefixedSeparator()
        {
            listWithNumbersToParse = listWithNumbersToParse
                .Substring(listWithNumbersToParse.IndexOf('\n') + 1);
        }

        private bool PrefixedWithDifferentSeparator(string listWithNumbersToParse)
        {
            return listWithNumbersToParse.StartsWith("//");
        }

        private bool ValidateInputNotEmpty(string input)
        {
            return string.IsNullOrEmpty(input);
        }

        private bool SeparatorsAreNotUsedAsDelimiters(string listWithNumbersToParse)
        {
            return listWithNumbersToParse.Length > 2;
        }
    }
}
