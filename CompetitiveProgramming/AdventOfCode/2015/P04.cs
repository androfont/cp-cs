using CompetitiveProgramming.Metadata;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace CompetitiveProgramming.AdventOfCode._2015;

[AlgorithmInfo(
    url: "https://adventofcode.com/2015/day/4",
    timeComplexity: ComplexityValues.Linear,
    memoryComplexity: ComplexityValues.Constant,
    new[] {
        AlgorithmTags.Adhoc, AlgorithmTags.BruteForce
    }
)]
class P04
{
    static StreamWriter output = new StreamWriter(Console.OpenStandardOutput());

    internal static void Run()
    {
        var input = Console.ReadLine();
        long result = MineWithLeading0(input, 6);
        output.WriteLine(result);
        output.Flush();
    }

    static long MineWithLeading0(string input, int zeroCount)
    {
        var startWith = new string('0', zeroCount);
        long result = -1;
        for (long i = 1; i < long.MaxValue; i++)
        {
            if (CreateMD5Hash(input + i.ToString()).StartsWith("000000"))
            {
                result = i;
                break;
            }
        }
        return result;
    }

    static string CreateMD5Hash(string input)
    {
        // Step 1, calculate MD5 hash from input
        var md5 = System.Security.Cryptography.MD5.Create();
        byte[] inputBytes = Encoding.ASCII.GetBytes(input);
        byte[] hashBytes = md5.ComputeHash(inputBytes);

        // Step 2, convert byte array to hex string
        var sb = new StringBuilder();
        for (int i = 0; i < hashBytes.Length; i++)
        {
            sb.Append(hashBytes[i].ToString("X2"));
        }
        return sb.ToString();
    }

    internal static void GenerateData()
    {
        Console.Write("yzbqklnj");
    }
}
