using System.Reflection.Emit;

namespace Day2
{
    internal class Program
    {
        static bool safe;

        static void Main(string[] args)
        {
            string[] inputLines = File.ReadAllLines("input.txt");

            int safeCount1 = 0;
            int safeCount2 = 0;

            for (int i = 0; i < inputLines.Length; i++)
            {
                string[] report = inputLines[i].Split(" ");

                safe = true;

                SafetyTest(report);

                if (safe)
                {
                    safeCount1++;
                }

                // if report is not safe without removing a level (part A) we try removing one level at a time (part B)
                else
                {
                    int levels = report.Length;

                    for (int k = 0; k < levels; k++)
                    {
                        report = inputLines[i].Split(" ");
                        List<string> reportList = report.ToList();
                        reportList.RemoveAt(k);
                        report = reportList.ToArray();

                        safe = true;

                        SafetyTest(report);

                        if (safe)
                        {
                            safeCount2++;
                            break;
                        }
                    }
                }
            }

            Console.WriteLine("Number of safe reports in part A: " + safeCount1);
            Console.WriteLine("Number of safe reports in part B: " + (safeCount1 + safeCount2));
        }

        // separate method for checking if a report is safe
        static void SafetyTest(string[] report)
        {
            int x = int.Parse(report[0]);
            int y = int.Parse(report[1]);

            if (Math.Abs(x - y) > 3 || x == y)
                safe = false;

            // we check if the start is increasing or decreasing and we use 1 or -1 to create a flip for greater than / less than comparison
            int sign = 1;
            if (x > y)
                sign = -1;

            // we check rest of the current report for unsafe situations
            for (int j = 2; j < report.Length; j++)
            {
                x = sign * int.Parse(report[j - 1]);
                y = sign * int.Parse(report[j]);

                if (x > y || x == y || Math.Abs(x - y) > 3)
                {
                    safe = false;
                    break;
                }
            }
        }
    }
}