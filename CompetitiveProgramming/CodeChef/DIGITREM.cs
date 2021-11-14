using CompetitiveProgramming.Metadata;
using System;
using System.IO;

namespace CompetitiveProgramming.CodeChef;

[AlgorithmInfo(
    url: "https://www.codechef.com/OCT21B/problems/DIGITREM",
    timeComplexity: ComplexityValues.Linear,
    memoryComplexity: ComplexityValues.Constant,
    new[] {
        AlgorithmTags.Adhoc
    }
)]
class DIGITREM
{
    static StreamWriter output = new StreamWriter(Console.OpenStandardOutput());

    internal static void Run()
    {
        int testCount = int.Parse(Console.ReadLine());
        for (int t = 0; t < testCount; t++)
        {
            var inputRaw = Console.ReadLine().Split();
            int n = int.Parse(inputRaw[0]);
            byte d = byte.Parse(inputRaw[1]);
            var result = Solve(n, d);
            output.WriteLine(result);
        }
        output.Flush();
    }

    public static long Solve(int n, byte d)
    {
        int number = n;
        int currentIndex = 0;
        int lastDigitIndex = -1;
        while (number > 0)
        {
            int currentDigit = number % 10;
            if (currentDigit == d)
            {
                lastDigitIndex = currentIndex;
            }
            number /= 10;
            currentIndex++;
        }

        if (lastDigitIndex == -1)
        {
            return 0;
        }
        if (lastDigitIndex == 0 && d != 9)
        {
            return 1;
        }
        long neededPow10 = IntPow(10, lastDigitIndex);
        if (d != 0)
        {
            var result = neededPow10 - (n % neededPow10);
            if (d != 9)
            {
                return result;
            }
            return Process9(n, result, neededPow10);
        }

        long needed1 = GetOneMask(lastDigitIndex);
        return needed1 - (n % neededPow10);
    }

    private static long GetOneMask(int lastDigitIndex)
    {
        long result = 1;
        for (int i = 0; i < lastDigitIndex; i++)
        {
            result *= 10;
            result++;
        }
        return result;
    }

    private static long Process9(int n, long result, long neededPow10)
    {
        neededPow10 *= 10;
        long number = n / neededPow10;
        while (number % 10 == 8)
        {
            result += neededPow10;
            number /= 10;
            neededPow10 *= 10;
        }

        return result;
    }

    private static long IntPow(long n, int e)
    {
        long result = 1;
        while (e > 0)
        {
            if ((e & 1) == 1)
            {
                result *= n;
            }
            n *= n;
            e >>= 1;
        }
        return result;
    }

    internal static void GenerateData()
    {
        var rd = new Random();
        int testCount = 100000;
        Console.WriteLine(testCount);
        int nMax = 1000000000;
        for (int t = 0; t < testCount; t++)
        {
            Console.WriteLine($"{rd.Next(nMax) + 1} {rd.Next(10)}");
        }
    }
}
