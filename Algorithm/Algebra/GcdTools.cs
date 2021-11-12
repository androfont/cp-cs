using static System.Math;

namespace Algorithm.Algebra;

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

    /// <summary>
    /// Calculates gcd(a,b) and also the coefficients of Bézout's identity, which are integers x and y such that ax+by=gcd(a, b).
    /// </summary>
    /// <param name="a">First value</param>
    /// <param name="b">Second value</param>
    /// <param name="x">Out first coefficients of Bézout's identity</param>
    /// <param name="y">Out second coefficients of Bézout's identity</param>
    /// <returns>Gcd(a,b). Provides x,y as out parameters</returns>
    public static int GcdExtended(int a, int b, out int x, out int y)
    {
        static int GcdExtendedInternal(int a, int b, out int x, out int y)
        {
            if (a == 0)
            {
                x = 0;
                y = 1;
                return b;
            }

            int gcd = GcdExtendedInternal(b % a, a, out int x1, out int y1);

            x = y1 - (b / a) * x1;
            y = x1;

            return gcd;
        }

        int gcd = GcdExtendedInternal(Abs(a), Abs(b), out x, out y);
        if (a < 0)
        {
            x = -x;
        }
        if (b < 0)
        {
            y = -y;
        }

        return gcd;
    }
}
