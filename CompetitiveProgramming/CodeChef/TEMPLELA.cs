using CompetitiveProgramming.Metadata;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace CompetitiveProgramming.CodeChef;

/// <summary>
/// https://www.codechef.com/SDPCB21/problems/TEMPLELA
/// Time Complexity: O(n)
/// Memory Complexity: O(1)
/// Tags: adhoc
/// </summary>
/// 
[AlgorithmInfo(
    url: "https://www.codechef.com/SDPCB21/problems/TEMPLELA",
    timeComplexity: ComplexityValues.Linear,
    memoryComplexity: ComplexityValues.Constant,
    new[] {
        AlgorithmTags.Adhoc
    }
)]
class TEMPLELA
{
    static StreamWriter output = new StreamWriter(Console.OpenStandardOutput());

    internal static void Run()
    {
        int testCount = int.Parse(Console.ReadLine());
        for (int t = 0; t < testCount; t++)
        {
            int l = int.Parse(Console.ReadLine());
            if ((l & 1) == 0)
            {
                output.WriteLine("no");
                Console.ReadLine();
                continue;
            }
            var steps = ReadArray(Console.ReadLine(), s => int.Parse(s)).ToArray();
            output.WriteLine(Solve(steps) ? "yes" : "no");
        }
        output.Flush();
    }

    static bool Solve(int[] steps)
    {
        for (int i = 0; i < steps.Length / 2; i++)
        {
            if (steps[i] != i + 1)
            {
                return false;
            }
        }

        int center = steps.Length / 2 + 1;
        if (steps[steps.Length / 2] != center)
        {
            return false;
        }

        for (int i = 0; i < steps.Length / 2; i++)
        {
            if (steps[center + i] != center - i - 1)
            {
                return false;
            }
        }

        return true;
    }

    static IEnumerable<T> ReadArray<T>(string arrayLine, Func<string, T> parseFunction, char separator = ' ')
    {
        int from = 0;
        for (int i = 0; i < arrayLine.Length; i++)
        {
            if (arrayLine[i] == separator)
            {
                yield return parseFunction(arrayLine.Substring(from, i - from));
                from = i + 1;
            }
        }

        yield return parseFunction(arrayLine.Substring(from));
    }

    internal static void GenerateData()
    {
        var rd = new Random();
        int testCount = 100;
        Console.WriteLine(testCount);
        int maxSteps = 100;

        for (int t = 0; t < testCount; t++)
        {
            int n = rd.Next(maxSteps - 2) + 3;
            Console.WriteLine(n);
            var h = new int[n];
            int middle = n / 2 + 1;
            for (int i = 0; i < n; i++)
            {
                if (i < middle)
                {
                    h[i] = i + 1;
                }
                else
                {
                    h[i] = 2 * middle - i - 1;
                }
            }
            if ((n & 1) == 1 && rd.Next(3) == 0)
            {
                int indexToModify = rd.Next(n);
                h[indexToModify]++;
            }
            Console.WriteLine(string.Join(' ', h));
        }
    }
}
