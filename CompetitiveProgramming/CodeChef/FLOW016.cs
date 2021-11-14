using CompetitiveProgramming.Metadata;
using System;
using System.IO;
using System.Linq;

namespace CompetitiveProgramming.CodeChef;

[AlgorithmInfo(
    url: "https://www.codechef.com/problems/FLOW016",
    timeComplexity: ComplexityValues.Log,
    memoryComplexity: ComplexityValues.Constant,
    new[] {
        AlgorithmTags.Gcd
    }
)]
class FLOW016
{
    static StreamWriter output = new StreamWriter(Console.OpenStandardOutput());

    internal static void Run()
    {
        int testCount = int.Parse(Console.ReadLine());
        for (int t = 0; t < testCount; t++)
        {
            var input = Console.ReadLine().Split(' ');
            long a = long.Parse(input[0]);
            long b = long.Parse(input[1]);
            var result = Solve(a, b);
            output.WriteLine($"{result[0]} {result[1]}");
        }
        output.Flush();
    }

    static long[] Solve(long a, long b)
    {
        long lcma = a;
        long lcmb = b;

        while (b > 0)
        {
            a %= b;
            // Swap a, b
            long temp = b;
            b = a;
            a = temp;
        }
        return new[] { a, lcma / a * lcmb };
    }

    internal static void GenerateData()
    {
        var rd = new Random();
        int testCount = 1000;
        Console.WriteLine(testCount);
        int maxValue = 1000000;
        for (int t = 0; t < testCount; t++)
        {
            Console.WriteLine(string.Join(' ', (new int[2]).Select((_, _) => rd.Next(maxValue) + 1)));
        }
    }
}
