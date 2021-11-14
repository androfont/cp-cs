using CompetitiveProgramming.Metadata;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace CompetitiveProgramming.CodeChef;

[AlgorithmInfo(
    url: "https://www.codechef.com/SDPCB21/problems/CHEFPRMS",
    timeComplexity: ComplexityValues.Cuadratic + " -> Generating prime combinations",
    memoryComplexity: ComplexityValues.Linear,
    new[] {
        AlgorithmTags.Prime,
        AlgorithmTags.Factorization,
        AlgorithmTags.Sieve
    }
)]
class CHEFPRMS
{
    static StreamWriter output = new StreamWriter(Console.OpenStandardOutput());

    internal static void Run()
    {
        int[] primes = SieveOfEratosthenes(102).ToArray();
        bool[] semiPrimesTable = new bool[primes[0] * primes[primes.Length - 1] + 1];
        for (int i = 0; i < primes.Length - 1; i++)
        {
            for (int j = i + 1; j < primes.Length; j++)
            {
                int index = primes[i] * primes[j];
                if (index < semiPrimesTable.Length)
                {
                    semiPrimesTable[index] = true;
                }
                else
                {
                    break;
                }
            }
        }

        int testCount = int.Parse(Console.ReadLine());
        for (int t = 0; t < testCount; t++)
        {
            int n = int.Parse(Console.ReadLine());
            bool ok = false;
            for (int i = 6; i <= n; i++)
            {
                if (semiPrimesTable[i] && semiPrimesTable[n - i])
                {
                    ok = true;
                    break;
                }
            }
            output.WriteLine(ok ? "YES" : "NO");
        }
        output.Flush();
    }

    static IEnumerable<int> SieveOfEratosthenes(int n)
    {
        bool[] prime = new bool[n + 1];

        for (int i = 2; i < prime.Length; i++)
        {
            prime[i] = true;
        }

        for (int p = 2; p * p < prime.Length; p++)
        {
            if (prime[p] == true)
            {
                // Update all multiples of p 
                for (int i = p * p; i < prime.Length; i += p)
                {
                    prime[i] = false;
                }
            }
        }

        for (int i = 2; i < prime.Length; i++)
        {
            if (prime[i] == true)
            {
                yield return i;
            }
        }
    }

    internal static void GenerateData()
    {
        var rd = new Random();
        int testCount = 200;
        Console.WriteLine(testCount);

        for (int t = 0; t < testCount; t++)
        {
            Console.WriteLine(rd.Next(200) + 1);
        }
    }
}
