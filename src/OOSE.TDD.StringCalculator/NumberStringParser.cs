using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOSE.TDD.StringCalculator
{
    public class NumberStringParser
    {
        private const string negativeText = "negatives not allowed ";
        private const string errorText = "Niet toegestane tekens in de lijst met cijfers.";
        private string listWithNumbersToParse;
        private readonly char[] separators = { ',', '\n' };

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
                    parsedNumbers.Add(ParseNumber(tokens[0]));
                    return parsedNumbers;
                }
            }

            // Negatieve getallen zijn niet toegestaan
            ThrowExceptionWhenListContainsNegatives(tokens);

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

        private void ThrowExceptionWhenListContainsNegatives(string[] tokens)
        {
            var negatives = tokens.Where(x => !string.IsNullOrEmpty(x) && int.Parse(x) < 0).ToArray();
            string exceptionMessage = negativeText;
            if (negatives.Any())
            {
                StringBuilder builder = new StringBuilder();
                builder.Append(exceptionMessage);
                foreach (var negative in negatives)
                {
                    builder.Append(negative);
                }
                throw new ArgumentException(builder.ToString());
            }
        }

        private int ParseNumber(string token)
        {
            if (int.TryParse(token, out int number))
            {
                if (number >= 0)
                {
                    return number;
                }
            }
            throw new ArgumentException(negativeText + number);
        }
    }
}
