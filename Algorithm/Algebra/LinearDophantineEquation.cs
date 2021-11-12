using System;
using System.Collections.Generic;

namespace Algorithm.Algebra;

public class LinearDophantineEquation
{
    private readonly long gcd;

    public long A { get; }

    public long B { get; }

    public long C { get; }

    public long X { get; }

    public long Y { get; }

    public bool HasSolution { get; }

    public LinearDophantineEquation(int a, int b, int c)
    {
        A = a;
        B = b;
        C = c;
        if (a == 0 && b == 0)
        {
            X = 0;
            Y = 1;
            HasSolution = c == 0;
        }
        else
        {
            gcd = GcdTools.GcdExtended(a, b, out int x, out int y);
            HasSolution = c % gcd == 0;
            if (HasSolution)
            {
                A = a / gcd;
                B = b / gcd;
                C = c / gcd;
            }
            X = x;
            Y = y;
        }
    }

    public (long X, long Y) GetInitialSolution()
    {
        if (!HasSolution)
        {
            throw new InvalidOperationException("Your equation doesn't have solution. Check first HasSolution property.");
        }
        if (A == 0 && B == 0)
        {
            return (0, 0);
        }
        if (A == 0)
        {
            return (0, C / B);
        }
        if (B == 0)
        {
            return (C / A, 0);
        }
        return (X * C, Y * C);
    }

    public IEnumerable<(long x, long y)> GetSolutionsInRange(long xFrom, long xTo, long yFrom, long yTo)
    {
        if (!HasSolution)
        {
            throw new InvalidOperationException("Your equation doesn't have solution. Check first HasSolution property.");
        }
        if (A == 0 && B == 0)
        {
            for (long i = xFrom; i <= xTo; i++)
            {
                for (long j = yFrom; j <= yTo; j++)
                {
                    yield return (i, j);
                }
            }
        }
        else if (A == 0)
        {
            for (long i = xFrom; i <= xTo; i++)
            {
                yield return (i, C / B);
            }
        }
        else if (B == 0)
        {
            for (long i = yFrom; i <= yTo; i++)
            {
                yield return (C / A, i);
            }
        }
        else
        {
            (long? lx, long? rx) = GetEffectiveInterval(xFrom, xTo, yFrom, yTo);
            if (!rx.HasValue)
            {
                yield break;
            }
            for (long i = lx.Value; i <= rx; i += B)
            {
                yield return (i, (C - A * i) / B);
            }
        }
    }

    public (long? x, long? y) MinimizeSolutionSum(long xFrom, long xTo, long yFrom, long yTo)
    {
        if (!HasSolution)
        {
            throw new InvalidOperationException("Your equation doesn't have solution. Check first HasSolution property.");
        }
        if (A == 0 && B == 0)
        {
            return (xFrom, yFrom);
        }
        if (A == 0)
        {
            long result = C / B;
            if (result >= yFrom && result <= yTo)
            {
                return (xFrom, result);
            }
            else
            {
                return (null, null);
            }
        }
        if (B == 0)
        {
            long result = C / A;
            if (result >= xFrom && result <= xTo)
            {
                return (result, yFrom);
            }
            else
            {
                return (null, null);
            }
        }

        (long? lx, long? rx) = GetEffectiveInterval(xFrom, xTo, yFrom, yTo);
        if (!rx.HasValue)
        {
            return (null, null);
        }

        if (A == 0)
        {
            return (0, C / B);
        }
        if (B == 0)
        {
            return (C / A, 0);
        }

        var initialSolution = GetInitialSolution();
        long k;
        if (A > B) //Maximize k in x = x0 + k * b/g
        {
            if (B < 0)
            {
                k = (lx.Value - initialSolution.X) / B;
            }
            else
            {
                k = (rx.Value - initialSolution.X) / B;
            }
        }
        else // Minimize k in x = x0 + k * b/g
        {
            if (B > 0)
            {
                k = (lx.Value - initialSolution.X) / B;
            }
            else
            {
                k = (rx.Value - initialSolution.X) / B;
            }
        }
        long x = initialSolution.X + k * B;
        return (x, (C - A * x) / B);
    }

    public (long? x, long? y) MaximizeSolutionSum(long xFrom, long xTo, long yFrom, long yTo)
    {
        if (!HasSolution)
        {
            throw new InvalidOperationException("Your equation doesn't have solution. Check first HasSolution property.");
        }
        if (A == 0 && B == 0)
        {
            return (xTo, yTo);
        }
        if (A == 0)
        {
            long result = C / B;
            if (result >= yFrom && result <= yTo)
            {
                return (xTo, result);
            }
            else
            {
                return (null, null);
            }
        }
        if (B == 0)
        {
            long result = C / A;
            if (result >= xFrom && result <= xTo)
            {
                return (result, yTo);
            }
            else
            {
                return (null, null);
            }
        }

        (long? lx, long? rx) = GetEffectiveInterval(xFrom, xTo, yFrom, yTo);
        if (!rx.HasValue)
        {
            return (null, null);
        }

        var initialSolution = GetInitialSolution();
        long k;
        if (A < B) //Maximize k in x = x0 + k * b/g
        {
            if (B < 0)
            {
                k = (lx.Value - initialSolution.X) / B;
            }
            else
            {
                k = (rx.Value - initialSolution.X) / B;
            }
        }
        else // Minimize k in x = x0 + k * b/g
        {
            if (B > 0)
            {
                k = (lx.Value - initialSolution.X) / B;
            }
            else
            {
                k = (rx.Value - initialSolution.X) / B;
            }
        }
        long x = initialSolution.X + k * B;
        return (x, (C - A * x) / B);
    }

    public long GetSolutionCountInRange(long xFrom, long xTo, long yFrom, long yTo)
    {
        if (!HasSolution)
        {
            throw new InvalidOperationException("Your equation doesn't have solution. Check first HasSolution property.");
        }
        if (A == 0 && B == 0)
        {
            return (xTo - xFrom + 1) * (yTo - yFrom + 1);
        }
        if (A == 0)
        {
            long result = C / B;
            if (result >= yFrom && result <= yTo)
            {
                return 1;
            }
            else
            {
                return 0;
            }
        }
        if (B == 0)
        {
            long result = C / A;
            if (result >= xFrom && result <= xTo)
            {
                return 1;
            }
            else
            {
                return 0;
            }
        }
        (long? lx, long? rx) = GetEffectiveInterval(xFrom, xTo, yFrom, yTo);
        if (!rx.HasValue)
        {
            return 0;
        }
        return (rx.Value - lx.Value) / Math.Abs(B) + 1;
    }

    public override string ToString()
    {
        return $"{A}x + {B}x = {C}\nx = {X} + k*{B / gcd}\ny = {Y} - k*{A / gcd}";
    }

    private (long? lx, long? rx) GetEffectiveInterval(long xFrom, long xTo, long yFrom, long yTo)
    {
        (long x, long y) = GetInitialSolution();

        int signA = A > 0 ? +1 : -1;
        int signB = B > 0 ? +1 : -1;

        (x, y) = ShiftSolution(x, y, (xFrom - x) / B);
        if (x < xFrom)
        {
            (x, y) = ShiftSolution(x, y, signB);
        }
        if (x > xTo)
        {
            return (null, null);
        }
        long lx1 = x;

        (x, y) = ShiftSolution(x, y, (xTo - x) / B);
        if (x > xTo)
        {
            (x, y) = ShiftSolution(x, y, -signB);
        }
        long rx1 = x;

        (x, y) = ShiftSolution(x, y, -(yFrom - y) / A);
        if (y < yFrom)
        {
            (x, y) = ShiftSolution(x, y, -signA);
        }
        if (y > yTo)
        {
            return (null, null);
        }
        long lx2 = x;

        (x, y) = ShiftSolution(x, y, -(yTo - y) / A);
        if (y > yTo)
        {
            (x, y) = ShiftSolution(x, y, signA);
        }
        long rx2 = x;

        if (lx2 > rx2)
        {
            var aux = lx2;
            lx2 = rx2;
            rx2 = aux;
        }
        long lx = Math.Max(lx1, lx2);
        long rx = Math.Min(rx1, rx2);

        if (lx > rx)
            return (null, null);

        return (lx, rx);
    }

    private (long X, long Y) ShiftSolution(long x, long y, long count)
    {
        return (x + count * B, y - count * A);
    }
}
