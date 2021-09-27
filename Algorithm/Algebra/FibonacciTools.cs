namespace Algorithm.Algebra
{
    public static class FibonacciTools
    {
        public static (int fn, int fn1) FibonacciN(uint n)
        {
            if (n == 0)
            {
                return (fn: 0, fn1: 1);
            }

            var p = FibonacciN(n >> 1);
            int c = p.fn * (2 * p.fn1 - p.fn);
            int d = p.fn * p.fn + p.fn1 * p.fn1;
            if ((n & 1) == 1)
            {
                return (fn: d, fn1: c + d);
            }
            else
            {
                return (fn: c, fn1: d);

            }
        }
    }
}
