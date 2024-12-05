using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Reflection.Metadata;

namespace Day3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = File.ReadAllText("input.txt");
            string numberChars = "0123456789,";
            char comma = ',';
            int sum = 0;

            bool enabled = true;

            for (int i = 6; i < input.Length; i++)
            {
                string firstFour = "" + input[i-6] + input[i-5] + input[i-4] + input[i-3];
                string firstSeven = "" + input[i - 6] + input[i - 5] + input[i - 4] + input[i - 3] + input[i - 2] + input[i - 1] + input[i];

                // we enable or disable instructions based on do's and dont's
                if (firstFour == "do()")
                {
                    enabled = true;
                    continue;
                }

                if (firstSeven == "don't()")
                {
                    enabled = false; // if this is switched to true we get part A answer
                    continue;
                }

                if (!enabled)
                    continue;

                if (firstFour != "mul(")
                    continue;

                // numbers and comma are 3...7 characters long inside the brackets
                List<char> characters = new();
                characters.Add(input[i-2]);
                characters.Add(input[i-1]);
                characters.Add(input[i]);

                int j = 0;

                // we add characters until we find the closing bracket
                while (input[i + 1 + j] != ')')
                {
                    characters.Add(input[i + 1 + j]);
                    j++;
                }

                // checks for too many characters inside brackets
                if (characters.Count > 7)
                    continue;

                // checks for too many commas
                List<char> commas = new List<char>(characters.FindAll(x => x == comma));
                if (commas.Count != 1)
                    continue;

                // comma cannot be next to brackets
                if (characters[0] == ',' || characters[characters.Count - 1] == ',')
                    continue;

                // characters must be numbers or comma
                for (int k = 0; k < characters.Count; k++)
                {
                    if (!numberChars.Contains(characters[k]))
                        goto Next;
                }

                char[] numbersArray = characters.ToArray();
                string numbersString = new string(numbersArray);
                string[] numbers = numbersString.Split(",");

                int number1 = int.Parse(numbers[0]);
                int number2 = int.Parse(numbers[1]);

                // numbers must be max 999
                if (number1 > 999 || number2 > 999)
                    continue;

                sum += number1 * number2;

            Next:;
            }

            Console.WriteLine("sum of the results: " + sum);
        }
    }
}
