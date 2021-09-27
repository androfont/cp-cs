using System;
using System.IO;
using System.Linq;

namespace CompetitiveProgramming.CodeSignal
{
    /// <summary>
    /// https://app.codesignal.com/interview-practice/task/FwAR7koSB3uYYsqDp/description
    /// Time Complexity: O(1)
    /// Memory Complexity: O(1)
    /// Tags: Bitwise
    /// </summary>
    class FindProfession
    {
        static StreamWriter output = new StreamWriter(Console.OpenStandardOutput());

        internal static void Run()
        {
            int testCount = int.Parse(Console.ReadLine());
            for (int t = 0; t < testCount; t++)
            {
                var input = Console.ReadLine().Split(' ');
                int pos = int.Parse(input[1]);
                output.WriteLine(Solve(pos - 1));
            }
            output.Flush();
        }

        public static string Solve(int pos)
        {
            int mask = (1 << 16) - 1;
            int bits = (pos >> 16) ^ (pos & mask);
            mask >>= 8;
            bits = (bits >> 8) ^ (bits & mask);
            mask >>= 4;
            bits = (bits >> 4) ^ (bits & mask);
            mask >>= 2;
            bits = (bits >> 2) ^ (bits & mask);
            mask >>= 1;
            bits = (bits >> 1) ^ (bits & mask);
            return bits == 1 ? "Doctor" : "Engineer";
        }

        internal static void GenerateData()
        {
            var rd = new Random();
            int testCount = 1;
            Console.WriteLine(testCount);

            for (int t = 0; t < testCount; t++)
            {
                Console.WriteLine(rd.Next(1 << 30));
            }
        }
    }
}
