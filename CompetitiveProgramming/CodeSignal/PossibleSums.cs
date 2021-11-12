using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace CompetitiveProgramming.CodeSignal;

/// <summary>
/// https://app.codesignal.com/interview-practice/task/rMe9ypPJkXgk3MHhZ/description
/// Time Complexity: O(Sum(coin[i]*quantity[i]*coins)
/// Memory Complexity: O(Sum(coin[i]*quantity[i])
/// Tags: hash-tables
/// </summary>
class PossibleSums
{
    static StreamWriter output = new StreamWriter(Console.OpenStandardOutput());

    internal static void Run()
    {
        int testCount = int.Parse(Console.ReadLine());
        for (int t = 0; t < testCount; t++)
        {
            var coins = ReadArray(Console.ReadLine(), s => int.Parse(s)).ToArray();
            var quantities = ReadArray(Console.ReadLine(), s => int.Parse(s)).ToArray();
            output.WriteLine(Solve(coins, quantities));
        }
        output.Flush();
    }

    static int Solve(int[] coins, int[] quantity)
    {
        int max = coins.Zip(quantity, (c, q) => c * q).Sum();
        var dp = new bool[max + 1];
        dp[0] = true;
        for (int i = 0; i < coins.Length; i++)
        {
            for (int j = 0; j < coins[i]; j++)
            {
                int num = -1;
                for (int k = j; k <= max; k += coins[i])
                {
                    if (dp[k])
                    {
                        num = 0;
                    }
                    else if (num >= 0)
                    {
                        num += 1;
                    }
                    dp[k] = 0 <= num && num <= quantity[i];
                }
            }
        }

        return dp.Sum(x => x ? 1 : 0) - 1;
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
        int testCount = 1;
        Console.WriteLine(testCount);
        int maxCoinCount = 20;
        int maxCoinValue = 10000;
        int maxCoinSum = 1000000;

        for (int t = 0; t < testCount; t++)
        {
            var coins = new int[rd.Next(maxCoinCount) + 1].Select((_, _) => rd.Next(maxCoinValue) + 1).ToArray();
            Console.WriteLine(string.Join(' ', coins));
            int coinSum = coins.Sum();
            var sb = new System.Text.StringBuilder();
            maxCoinSum -= coinSum;
            for (int i = 0; i < coins.Count(); i++)
            {
                int quantity = rd.Next(maxCoinSum / coins[i]);
                maxCoinSum -= quantity * coins[i];
                sb.Append(quantity + 1);
                sb.Append(' ');
            }
            Console.WriteLine(sb.Remove(sb.Length - 1, 1).ToString());
        }
    }
}
