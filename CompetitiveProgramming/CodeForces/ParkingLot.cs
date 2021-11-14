using CompetitiveProgramming.Metadata;
using System;
using System.IO;

namespace CompetitiveProgramming.CodeForces;

[AlgorithmInfo(
    url: "https://www.codechef.com/OCT21B/problems/MEXOR",
    timeComplexity: ComplexityValues.Log,
    memoryComplexity: ComplexityValues.Constant,
    new[] {
        AlgorithmTags.Math,
        AlgorithmTags.Combinatory,
        AlgorithmTags.BinaryExponentiation
    }
)]
class ParkingLot
{
    static StreamWriter output = new StreamWriter(Console.OpenStandardOutput());

    internal static void Run()
    {
        var input = Console.ReadLine();
        output.WriteLine(input);
        output.WriteLine(Solve(int.Parse(input)));
        output.Flush();
    }

    static long Solve(int n)
    {
        var a = IntPow(4L, n - 3);
        return 24 * a + 9 * a * (n - 3);
    }

    static long IntPow(long b, int e)
    {
        long result = 1;
        while (e > 0)
        {
            if ((e & 1) == 1)
            {
                result *= b;
            }
            b *= b;
            e >>= 1;
        }
        return result;
    }

    internal static void GenerateData()
    {
        var rd = new Random();
        Console.WriteLine(rd.Next(28) + 3);
    }
}
