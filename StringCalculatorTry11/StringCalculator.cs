using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace StringCalculatorTry11
{
    public class StringCalculator
    {
        public int Add(string input)
        {
            var stringParts = GetStringParts(input);
            var numbers = GetNumbers(stringParts);
            var negatives = GetNegatives(numbers);
            if (HasNegatives(negatives))
            {
                var message = "negatives not allowed: " + numbers.First();
                throw new ApplicationException(message);
            }
            return string.IsNullOrEmpty(input) ? 0 : numbers.Sum();
        }

        private static IEnumerable<int> GetNegatives(IEnumerable<int> numbers)
        {
            return numbers.Where(x=>x < 0);
        }

        private static bool HasNegatives(IEnumerable<int> negatives)
        {
            return negatives.Any();
        }

        private static IEnumerable<int> GetNumbers(string[] stringParts)
        {
            return stringParts.Select(x => ParseInt(x)).Where(x=>x <= 1000);
        }

        private static string[] GetStringParts(string input)
        {
            var separator = GetSeparator();
            if (input.StartsWith("//"))
            {
                var parts = SplitIntoParts(input);
                var delimeterPart = parts.First();
                var customDelimeter = GetCustomDelimeter(delimeterPart);
                separator.AddRange(customDelimeter);
                var stringPart = parts.Last();
                input = stringPart;
            }
            return input.Split(separator.ToArray(), StringSplitOptions.RemoveEmptyEntries);
        }

        private static string[] GetCustomDelimeter(string delimeterPart)
        {
            return delimeterPart.TrimStart("//".ToCharArray()).Split(new []{"[","]"},StringSplitOptions.RemoveEmptyEntries);
        }

        private static string[] SplitIntoParts(string input)
        {
            return input.Split(new[] {"\n"}, StringSplitOptions.RemoveEmptyEntries);
        }

        private static List<string> GetSeparator()
        {
            return new List<string> {",", "\n"};
        }

        private static int ParseInt(string input)
        {
            return int.Parse(input);
        }
    }
}