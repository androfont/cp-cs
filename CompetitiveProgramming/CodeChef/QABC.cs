using CompetitiveProgramming.Metadata;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace CompetitiveProgramming.CodeChef;

[AlgorithmInfo(
    url: "https://www.codechef.com/SDPCB21/problems/QABC",
    timeComplexity: ComplexityValues.Linear,
    memoryComplexity: ComplexityValues.Constant,
    new[] {
        AlgorithmTags.Adhoc
    }
)]
class QABC
{
    static StreamWriter output = new StreamWriter(Console.OpenStandardOutput());

    internal static void Run()
    {
        int testCount = int.Parse(Console.ReadLine());
        for (int t = 0; t < testCount; t++)
        {
            Console.ReadLine();

            var a = ReadArray(Console.ReadLine(), s => int.Parse(s)).ToArray();
            var b = ReadArray(Console.ReadLine(), s => int.Parse(s)).ToArray();
            output.WriteLine(Solve(a, b) ? "TAK" : "NIE");
        }
        output.Flush();
    }

    static bool Solve(int[] a, int[] b)
    {
        for (int i = 0; i < a.Length - 2; i++)
        {
            if (a[i] > b[i])
            {
                return false;
            }

            int diff = b[i] - a[i];
            a[i] += diff;
            a[i + 1] += 2 * diff;
            a[i + 2] += 3 * diff;
        }

        return a[a.Length - 1] == b[b.Length - 1] && a[a.Length - 2] == b[b.Length - 2];
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
        Console.WriteLine(2);
        Console.WriteLine(5);
        Console.WriteLine("0 0 0 0 0");
        Console.WriteLine("1 2 4 2 3");
        Console.WriteLine(5);
        Console.WriteLine("0 0 0 0 0");
        Console.WriteLine("1 2 4 2 4");
    }
}
