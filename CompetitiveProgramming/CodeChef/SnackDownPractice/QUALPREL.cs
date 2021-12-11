using CompetitiveProgramming.Metadata;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace CompetitiveProgramming.CodeChef.SnacDownPractice;

[AlgorithmInfo(
    url: "https://www.codechef.com/SDPCB21/problems/QUALPREL",
    timeComplexity: ComplexityValues.Linear,
    memoryComplexity: ComplexityValues.Constant,
    new[] {
        AlgorithmTags.Adhoc
    }
)]
class QUALPREL
{
    static StreamWriter output = new StreamWriter(Console.OpenStandardOutput());

    internal static void Run()
    {
        int testCount = int.Parse(Console.ReadLine());
        for (int t = 0; t < testCount; t++)
        {
            var input = Console.ReadLine().Split();
            int k = int.Parse(input[1]);

            var scores = ReadArray(Console.ReadLine(), x => int.Parse(x)).ToArray();
            Array.Sort(scores, (x, y) => y.CompareTo(x));
            var value = scores[k - 1];
            int result = k;
            while (k < scores.Length && scores[k] == value)
            {
                result++;
                k++;
            }

            output.WriteLine(result);
        }
        output.Flush();
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
        int testCount = 1000;
        Console.WriteLine(testCount);

        int maxkn = 100000;
        for (int t = 0; t < testCount; t++)
        {
            int n = rd.Next(maxkn) + 1;
            int k = rd.Next(n) + 1;
            Console.WriteLine($"{n} {k}");
            Console.WriteLine(string.Join(' ', (new int[n]).Select((_, _) => rd.Next(1000000000) + 1)));
        }
    }
}
