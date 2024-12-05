using System.Data.Common;

namespace Day4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] rows = File.ReadAllLines("input.txt");
            string[] columns = new string[rows.Length];

            // create columns starting from the right side
            for (int y = 0; y < rows.Length; y++)
            {
                int i = 0;

                for (int x = rows[y].Length - 1; x > -1; x--)
                {
                    columns[i] += rows[y][x];
                    i++;
                }
            }

            // Part A

            int sum = 0;

            // horizontal
            for (int y = 0; y < rows.Length; y++)
            {
                for (int x = 3; x < rows[y].Length; x++)
                {
                    char[] chars = { rows[y][x - 3], rows[y][x - 2], rows[y][x - 1], rows[y][x] };
                    string word = new (chars);

                    if (word == "XMAS" ||  word == "SAMX")
                        sum++;
                }
            }

            // vertical
            for (int x = 0; x < columns.Length; x++)
            {
                for (int y = 3; y < columns[x].Length; y++)
                {
                    char[] chars = { columns[x][y - 3], columns[x][y - 2], columns[x][y - 1], columns[x][y] };
                    string word = new (chars);

                    if (word == "XMAS" || word == "SAMX")
                        sum++;
                }
            }

            // diagonal from top left to bottom right
            for (int y = 3; y < rows.Length; y++)
            {
                for (int x = 3; x < rows[y].Length; x++)
                {
                    char[] chars = { rows[y - 3][x - 3], rows[y - 2][x - 2], rows[y - 1][x - 1], rows[y][x] };
                    string word = new(chars);

                    if (word == "XMAS" || word == "SAMX")
                        sum++;
                }
            }

            // diagonal from top right to bottom left
            for (int x = 3; x < columns.Length; x++)
            {
                for (int y = 3; y < columns[x].Length; y++)
                {
                    char[] chars = { columns[x - 3][y - 3], columns[x - 2][y - 2], columns[x - 1][y - 1], columns[x][y] };
                    string word = new(chars);

                    if (word == "XMAS" || word == "SAMX")
                        sum++;
                }
            }

            Console.WriteLine("Part A sum: " + sum);

            // Part B

            int sumB = 0;

            // diagonal from top left to bottom right
            for (int y = 2; y < rows.Length; y++)
            {
                for (int x = 2; x < rows[y].Length; x++)
                {
                    if (rows[y - 1][x - 1] != 'A')
                        continue;

                    char[] chars1 = { rows[y - 2][x - 2], rows[y][x] };
                    string word1 = new(chars1);

                    char[] chars2 = { rows[y - 2][x], rows[y][x - 2] };
                    string word2 = new(chars2);

                    if ((word1 == "SM" || word1 == "MS") && (word2 == "SM" || word2 == "MS"))
                        sumB++;
                }
            }

            Console.WriteLine("Part B sum: " + sumB);
        }
    }
}
