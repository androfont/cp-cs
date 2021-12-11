using CompetitiveProgramming.Metadata;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace CompetitiveProgramming.CodeChef.SnacDownPractice;

[AlgorithmInfo(
    url: "https://www.codechef.com/SDPCB21/problems/TYPING",
    timeComplexity: ComplexityValues.Linear,
    memoryComplexity: ComplexityValues.Linear,
    new[] {
        AlgorithmTags.Adhoc
    }
)]
class TYPING
{
    static Dictionary<string, int> memo;

    static StreamWriter output = new StreamWriter(Console.OpenStandardOutput());

    internal static void Run()
    {
        int testCount = int.Parse(Console.ReadLine());
        for (int t = 0; t < testCount; t++)
        {
            int wordCount = int.Parse(Console.ReadLine());
            memo = new Dictionary<string, int>();
            int result = 0;

            for (int i = 0; i < wordCount; i++)
            {
                string word = Console.ReadLine();
                int value;
                if (memo.TryGetValue(word, out value))
                {
                    result += value / 2;
                    continue;
                }

                bool hand = !IsRightHand(word[0]);

                int wordTime = 0;
                foreach (var c in word)
                {
                    var newHand = IsRightHand(c);
                    if (hand != newHand)
                    {
                        wordTime += 2;
                    }
                    else
                    {
                        wordTime += 4;
                    }
                    hand = newHand;
                }
                result += wordTime;
                memo.Add(word, wordTime);
            }
            output.WriteLine(result);
        }
        output.Flush();
    }

    static bool IsRightHand(char c)
    {
        if (c == 'd' || c == 'f')
        {
            return false;
        }
        return true;
    }

    internal static void GenerateData()
    {
        var rd = new Random();
        int testCount = 100;
        Console.WriteLine(testCount);
        char[] table = new[] { 'd', 'f', 'j', 'k' };
        for (int t = 0; t < testCount; t++)
        {
            int n = rd.Next(100);
            for (int j = 0; j < n; j++)
            {
                Console.WriteLine(new string(new char[rd.Next(20) + 1]).Select((_, _) => table[rd.Next(table.Length) + 1]));
            }
        }
    }
}
