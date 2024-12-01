using System.Collections.Generic;
using System;

namespace Day1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // we get the rows from the input file (default location for input file in visual studio C# console app is bin/Debug/net8.0)
            string[] inputLines = File.ReadAllLines("input.txt");

            // we create two empty integer lists
            List<int> list1 = new List<int>();
            List<int> list2 = new List<int>();

            // we create separate lists for part B because we modify lists in part A
            List<int> list1b = new List<int>();
            List<int> list2b = new List<int>();

            // we split every row using the 3 spaces between the numbers and then we add the numbers into two separate lists
            for (int i = 0; i < inputLines.Length; i++)
            {
                string[] line = inputLines[i].Split("   ");

                // we need to convert the numbers from string to int
                int number1 = int.Parse(line[0]);
                int number2 = int.Parse(line[1]);

                list1.Add(number1);
                list2.Add(number2);

                list1b.Add(number1);
                list2b.Add(number2);
            }

            // part A

            int totalDistance = 0;

            // we use the length of the original list to determine the number of iterations, because the size of the two lists changes after removing numbers from them
            for (int i = 0; i < inputLines.Length; i++)
            {
                // we get the smallest value from each list
                int smallest1 = list1.Min();
                int smallest2 = list2.Min();

                // we remove the smallest value from each list so that we get the next smallest numbers in the next iteration
                list1.Remove(smallest1);
                list2.Remove(smallest2);

                // we calculate the distance between the smallest numbers and add it to the total distance
                int distance = Math.Abs(smallest1 - smallest2);
                totalDistance += distance;
            }

            Console.WriteLine("Total distance: " + totalDistance);

            // part B

            int totalSimScore = 0;

            foreach (int number1 in list1b)
            {
                int matches = 0;

                // one way to count the matching numbers is by doing another for-loop inside the first one which goes through every number in list2 and checks for same numbers
                foreach (int number2 in list2b)
                {
                    if (number1 == number2)
                    {
                        matches++;
                    }
                }

                // another option is to create a list which includes all the current numbers from list 2 (this way we also get the amount)
                //List<int> matches = new List<int>(list2b.FindAll(x => x == number));

                // we calculate the similarity score by multiplying number with amount of matches, and then we add it to the total
                int simScore = number1 * matches;
                totalSimScore += simScore;
            }

            Console.WriteLine("Similarity score: " + totalSimScore);
        }
    }
}
