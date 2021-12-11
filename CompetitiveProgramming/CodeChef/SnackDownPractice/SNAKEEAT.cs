using CompetitiveProgramming.Metadata;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace CompetitiveProgramming.CodeChef.SnacDownPractice;

[AlgorithmInfo(
    url: "https://www.codechef.com/SDPCB21/problems/SNAKEEAT",
    timeComplexity: ComplexityValues.Nlog,
    memoryComplexity: ComplexityValues.Constant,
    new[] {
        AlgorithmTags.BinarySearch
    }
)]
class SNAKEEAT
{
    static StreamWriter output = new StreamWriter(Console.OpenStandardOutput());

    internal static void Run()
    {
        int testCount = int.Parse(Console.ReadLine());
        for (int t = 0; t < testCount; t++)
        {
            int queryCount = int.Parse(Console.ReadLine().Split()[1]);
            var snakes = ReadArray(Console.ReadLine(), s => int.Parse(s)).ToArray();
            Array.Sort(snakes);
            for (int i = 0; i < queryCount; i++)
            {
                int q = int.Parse(Console.ReadLine());
                int result = 0;
                int from = 0;
                int to = Array.BinarySearch(snakes, q);
                while (to >= 0)
                {
                    to = Array.BinarySearch(snakes, from, to, q);
                }
                to = ~to;
                result = snakes.Length - to;
                to--;
                while (from < to)
                {
                    int diff = q - snakes[to];
                    if (to - from >= diff)
                    {
                        result++;
                    }
                    to--;
                    from += diff;
                }
                output.WriteLine(result);
            }
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
        int testCount = 5;
        Console.WriteLine(testCount);

        for (int t = 0; t < testCount; t++)
        {
            Console.WriteLine($"{100000} {100000}");
            Console.WriteLine(string.Join(' ', (new int[100000]).Select((_, _) => rd.Next(1000000000) + 1)));
            for (int i = 0; i < 100000; i++)
            {
                Console.WriteLine(rd.Next(1000000000));
            }
        }
    }
}
