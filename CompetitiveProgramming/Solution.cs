using CompetitiveProgramming.Metadata;
using System;
using System.IO;
using System.Linq;

namespace CompetitiveProgramming;

[AlgorithmInfo(
    url: "",
    timeComplexity: ComplexityValues.Constant,
    memoryComplexity: ComplexityValues.Constant,
    new[] {
        AlgorithmTags.Unknown
    }
)]
class Solution
{
    static StreamWriter output = new StreamWriter(Console.OpenStandardOutput());

    internal static void Run()
    {
        int testCount = int.Parse(Console.ReadLine());
        for (int t = 0; t < testCount; t++)
        {
            output.WriteLine(Solve());
        }
        output.Flush();
    }

    static int Solve()
    {
        return 0;
    }

    internal static void GenerateData()
    {
        var rd = new Random();
        int testCount = 1;
        Console.WriteLine(testCount);

        for (int t = 0; t < testCount; t++)
        {
            Console.WriteLine(string.Join(' ', (new int[10]).Select((_, _) => rd.Next(100) + 1)));
        }
    }
}
