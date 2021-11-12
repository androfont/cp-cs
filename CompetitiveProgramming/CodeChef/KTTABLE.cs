using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace CompetitiveProgramming.CodeChef;

/// <summary>
/// https://www.codechef.com/SDPCB21/problems/KTTABLE
/// Time Complexity: O(n)
/// Memory Complexity: O(1)
/// Tags: adhoc
/// </summary>
class KTTABLE
{
    static StreamWriter output = new StreamWriter(Console.OpenStandardOutput());

    internal static void Run()
    {
        int testCount = int.Parse(Console.ReadLine());
        for (int t = 0; t < testCount; t++)
        {
            Console.ReadLine();
            var time = ReadArray(Console.ReadLine(), s => int.Parse(s)).ToArray();
            var cookTime = ReadArray(Console.ReadLine(), s => int.Parse(s)).ToArray();
            output.WriteLine(Solve(time, cookTime));
        }
        output.Flush();
    }

    static int Solve(int[] time, int[] cookTime)
    {
        int result = 0;
        int current = 0;
        for (int i = 0; i < time.Length; i++)
        {
            if (time[i] - current >= cookTime[i])
            {
                result++;
            }
            current = time[i];
        }

        return result;
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
        int testCount = 10;
        Console.WriteLine(testCount);
        int nMax = 10000;
        int timeMax = 1000000000;
        int n = rd.Next(nMax) + 1;
        Console.WriteLine(n);

        for (int t = 0; t < testCount; t++)
        {
            int[] times = (new int[n]).Select((_, _) => rd.Next(timeMax) + 1).ToArray();
            Array.Sort(times);
            int currentTime = -1;
            for (int i = 0; i < times.Length - 1; i++)
            {
                if (currentTime <= times[i])
                {
                    times[i] = currentTime + 1;
                    currentTime = times[i];
                }
            }

            Console.WriteLine(string.Join(' ', (new int[n]).Select((_, _) => rd.Next(timeMax) + 1)));
        }
    }
}
