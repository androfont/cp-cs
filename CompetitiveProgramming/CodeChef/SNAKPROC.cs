using System;
using System.IO;

namespace CompetitiveProgramming.CodeChef;

/// <summary>
/// https://www.codechef.com/SDPCB21/problems/SNAKPROC
/// Time Complexity: O(n)
/// Memory Complexity: O(1)
/// Tags: adhoc
/// </summary>
class SNAKPROC
{
    static StreamWriter output = new StreamWriter(Console.OpenStandardOutput());

    internal static void Run()
    {
        int testCount = int.Parse(Console.ReadLine());
        for (int t = 0; t < testCount; t++)
        {
            Console.ReadLine();
            var report = Console.ReadLine();
            output.WriteLine(Solve(report) ? "Valid" : "Invalid");
        }
        output.Flush();
    }

    static bool Solve(string report)
    {
        char current = 'T';

        foreach (var c in report)
        {
            if (c == 'H')
            {
                if (current == 'H')
                {
                    return false;
                }
                else
                {
                    current = c;
                }
            }
            else if (c == 'T')
            {
                if (current == 'T')
                {
                    return false;
                }
                else
                {
                    current = c;
                }
            }
        }

        return current == 'T';
    }

    internal static void GenerateData()
    {
        var rd = new Random();
        int testCount = 500;
        Console.WriteLine(testCount);
        char[] table = new[] { 'H', '.', 'T' };
        for (int t = 0; t < testCount; t++)
        {
            int l = rd.Next(500) + 1;
            Console.WriteLine(l);
            char[] report = new char[l];
            bool isHead = true;
            for (int j = 0; j < l - 1; j++)
            {
                if (isHead)
                {
                    report[j] = table[rd.Next(2)];
                }
                else
                {
                    report[j] = table[rd.Next(2) + 1];
                }
                isHead = !isHead;
            }
            if (!isHead)
            {
                report[l - 1] = 'T';
            }
            else
            {
                report[l - 1] = '.';
            }

            if (rd.Next(2) == 0)
            {
                int indexToModify = rd.Next(l - 1);
                if (report[indexToModify] == 'H')
                {
                    report[indexToModify] = table[rd.Next(2) + 1];
                }
                else
                {
                    report[indexToModify] = table[rd.Next(2)];
                }
            }
            Console.WriteLine();
        }
    }
}
