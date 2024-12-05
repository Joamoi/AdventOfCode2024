using System.Numerics;

namespace Day5
{
    internal class Program
    {
        static void Main(string[] args)
        {
            String[] rules = File.ReadAllLines("rules.txt");
            String[] updates = File.ReadAllLines("updates.txt");

            int[] xs = new int[rules.Length];
            int[] ys = new int[rules.Length];

            for (int i = 0; i < rules.Length; i++)
            {
                String[] rule = rules[i].Split("|");
                xs[i] = int.Parse(rule[0]);
                ys[i] = int.Parse(rule[1]);
            }

            int sumA = 0;
            int sumB = 0;

            // we go through every update line
            for (int i = 0; i < updates.Length; i++)
            {
                String[] update = updates[i].Split(",");

                bool correct = true;

                // we go through every rule for the current update line
                for (int j = 0; j < rules.Length; j++)
                {
                    int x = xs[j];
                    int y = ys[j];

                    int indexX = 0;
                    int indexY = 0;

                    bool foundX = false;
                    bool foundY = false;

                    // we check if update line contains both values of current rule
                    for (int k = 0; k < update.Length; k++)
                    {
                        if (x == int.Parse(update[k]))
                        {
                            foundX = true;
                            indexX = k;
                            continue;
                        }

                        if (y == int.Parse(update[k]))
                        {
                            foundY = true;
                            indexY = k;
                            continue;
                        }
                    }

                    if (!(foundX && foundY))
                        continue;

                    // if rule values are found, they have to be in a correct order, otherwise we switch bool to false
                    if(indexX > indexY)
                        correct = false;
                }

                // if current update followed all the rules, we add the middle update value to the sum
                if (correct)
                {
                    int middle = update.Length / 2;
                    sumA += int.Parse(update[middle]);

                    Console.WriteLine("Correct right away\t" + updates[i]);
                }

                else
                {
                    int loopCounter = 0;
                    int switchCounter = 0;

                    // we switch positions of update values until the line follows every rule
                    while (!correct)
                    {
                        correct = true;

                        // we go through every rule for the current update line
                        for (int j = 0; j < rules.Length; j++)
                        {
                            int x = xs[j];
                            int y = ys[j];

                            int indexX = 0;
                            int indexY = 0;

                            bool foundX = false;
                            bool foundY = false;

                            // we check if update line contains both values of current rule
                            for (int k = 0; k < update.Length; k++)
                            {
                                if (x == int.Parse(update[k]))
                                {
                                    foundX = true;
                                    indexX = k;
                                    continue;
                                }

                                if (y == int.Parse(update[k]))
                                {
                                    foundY = true;
                                    indexY = k;
                                    continue;
                                }
                            }

                            if (!(foundX && foundY))
                                continue;

                            // if rule values are found and they are in the wrong order, we flip their positions
                            if (indexX > indexY)
                            {
                                correct = false;
                                update[indexX] = y.ToString();
                                update[indexY] = x.ToString();
                                switchCounter++;
                            }
                        }

                        loopCounter++;
                    }

                    // when the current line follows every rule, we add the middle update value to the sum
                    int middle = update.Length / 2;
                    sumB += int.Parse(update[middle]);

                    Console.WriteLine(loopCounter + " loops, " + switchCounter + " switches\t" + updates[i]);
                }
            }

            Console.WriteLine("\nSum of middle values of correct updates: " + sumA);
            Console.WriteLine("Sum of middle values of incorrect updates after correcting: " + sumB);
        }
    }
}
