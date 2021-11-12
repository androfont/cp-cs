using System;
using System.IO;

namespace CompetitiveProgramming.CodeChef;

/// <summary>
/// https://www.codechef.com/OCT21B/problems/MEXOR
/// Time Complexity: O(n) -> bit length
/// Memory Complexity: O(1)
/// Tags: bitwise
/// </summary>
class MEXOR
{
    static StreamWriter output = new StreamWriter(Console.OpenStandardOutput());

    internal static void Run()
    {
        int testCount = int.Parse(Console.ReadLine());
        for (int t = 0; t < testCount; t++)
        {
            int n = int.Parse(Console.ReadLine());
            int mask = 1;
            while (mask - 1 <= n)
            {
                mask <<= 1;
            }
            int result = (mask >> 1);
            output.WriteLine(result);
        }
        output.Flush();
    }

    internal static void GenerateData()
    {
        var rd = new Random();
        int testCount = 100000;
        Console.WriteLine(testCount);

        for (int t = 0; t < testCount; t++)
        {
            Console.WriteLine(rd.Next(1000000000) + 1);
        }
    }
}
