namespace Algorithm.Algebra
{
    public static class GcdTools
    {
        public static int Gcd(int a, int b)
        {
            while (b > 0)
            {
                a %= b;
                // Swap a, b
                int temp = b;
                b = a;
                a = temp;
            }
            return a;
        }

        public static int Lcm(int a, int b)
        {
            return a / Gcd(a, b) * b;
        }
    }
}
