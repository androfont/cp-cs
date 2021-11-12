using System.Collections.Generic;
using System.Linq;
using static System.Array;
using static System.Math;

namespace Algorithm.Algebra.PrimeNumbers;

public static class SieveOfEratosthenesTools
{
    public static IEnumerable<int> SieveOfEratosthenes(int n)
    {
        bool[] prime = new bool[n - 1];

        for (int i = 0; i < n - 1; i++)
        {
            prime[i] = true;
        }

        // Only for 2
        for (int i = 4; i <= n; i += 2)
        {
            prime[i - 2] = false;
        }

        for (int p = 3; p * p <= n; p += 2)
        {
            if (prime[p - 2] == true)
            {
                // Update all multiples of p 
                for (int i = p * p; i <= n; i += p)
                {
                    prime[i - 2] = false;
                }
            }
        }

        for (int i = 2; i <= n; i++)
        {
            if (prime[i - 2] == true)
            {
                yield return i;
            }
        }
    }

    public static IEnumerable<int> BlockSieveOfEratosthenes(int n)
    {
        const int blockSize = 10000;

        var nsqrt = (int)Sqrt(n);
        var primes = SieveOfEratosthenes(nsqrt).ToList();

        var block = new bool[blockSize];
        for (int k = 0; k * blockSize <= n; k++)
        {
            Fill(block, true);
            int start = k * blockSize;
            foreach (int p in primes)
            {
                int startIndex = (start + p - 1) / p;
                int j = Max(startIndex, p) * p - start;
                for (; j < blockSize; j += p)
                {
                    block[j] = false;
                }
            }
            if (k == 0)
            {
                block[0] = block[1] = false;
            }
            for (int i = 0; i < blockSize && start + i <= n; i++)
            {
                if (block[i])
                {
                    yield return k * blockSize + i;
                }
            }
        }
    }

    public static IEnumerable<int> SegmentedSieveOfEratosthenes(int l, int r)
    {
        var nsqrt = (int)Sqrt(r);
        var primes = SieveOfEratosthenes(nsqrt).ToList();

        var isPrime = new bool[r - l + 1];
        Fill(isPrime, true);
        foreach (var i in primes)
        {
            for (int j = Max(i * i, (l + i - 1) / i * i); j <= r; j += i)
            {
                isPrime[j - l] = false;
            }
        }

        if (l == 1)
        {
            isPrime[0] = false;
        }

        for (int i = 0; i < isPrime.Length; i++)
        {
            if (isPrime[i] == true)
            {
                yield return l + i;
            }
        }
    }
}
