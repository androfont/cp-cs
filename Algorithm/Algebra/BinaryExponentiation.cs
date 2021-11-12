namespace Algorithm.Algebra;

public static class BinaryExponentiation
{
    public static long IntPow(long n, ulong e)
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

    public static long IntPowMod(long n, ulong e, long mod)
    {
        n %= mod;
        long result = 1;
        while (e > 0)
        {
            if ((e & 1) == 1)
            {
                result = result * n % mod;
            }
            n = (n * n) % mod;
            e >>= 1;
        }
        return result;
    }
}
