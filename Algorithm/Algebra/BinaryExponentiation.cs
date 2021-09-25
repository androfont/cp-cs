namespace Algorithm.Algebra
{
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
    }
}
