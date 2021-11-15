using Algorithm.Algebra.PrimeNumbers;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace Algorithm.Tests.Algebra.PrimeNumbers;

public class PrimeSieveToolsTests
{
    [Fact]
    public void SieveOfEratosthenes_ToN_Ok()
    {
        // Arrange
        int n = 16;

        // Act
        var result = PrimeSieveTools.SieveOfEratosthenes(n).ToArray();

        // Assert
        Assert.Equal(6, result.Length);
        Assert.Equal(2, result[0]);
        Assert.Equal(3, result[1]);
        Assert.Equal(5, result[2]);
        Assert.Equal(7, result[3]);
        Assert.Equal(11, result[4]);
        Assert.Equal(13, result[5]);

    }

    [Fact]
    public void BlockSieveOfEratosthenes_ToN_Ok()
    {
        // Arrange
        int n = 71;

        // Act
        var result = PrimeSieveTools.BlockSieveOfEratosthenes(n).ToArray();

        // Assert
        Assert.Equal(20, result.Length);
        Assert.Equal(2, result[0]);
        Assert.Equal(3, result[1]);
        Assert.Equal(5, result[2]);
        Assert.Equal(7, result[3]);
        Assert.Equal(11, result[4]);

        Assert.Equal(53, result[^5]);
        Assert.Equal(59, result[^4]);
        Assert.Equal(61, result[^3]);
        Assert.Equal(67, result[^2]);
        Assert.Equal(71, result[^1]);
    }

    [Fact]
    public void SegmentedSieveOfEratosthenes_LtoR_Ok()
    {
        // Arrange
        int l = 130;
        int r = 155;

        // Act
        var result = PrimeSieveTools.SegmentedSieveOfEratosthenes(l, r).ToArray();

        // Assert
        Assert.Equal(5, result.Length);
        Assert.Equal(131, result[0]);
        Assert.Equal(137, result[1]);
        Assert.Equal(139, result[2]);
        Assert.Equal(149, result[3]);
        Assert.Equal(151, result[4]);
    }

    [Fact]
    public void EulerSieve_ToN_Ok()
    {
        // Arrange
        int n = 16;

        // Act
        var result = PrimeSieveTools.EulerSieve(n, out IList<int> lowestPrimes).ToArray();

        // Assert
        Assert.Equal(6, result.Length);
        Assert.Equal(2, result[0]);
        Assert.Equal(3, result[1]);
        Assert.Equal(5, result[2]);
        Assert.Equal(7, result[3]);
        Assert.Equal(11, result[4]);
        Assert.Equal(13, result[5]);

        Assert.Equal(17, lowestPrimes.Count);
        Assert.Equal(2, lowestPrimes[6]);
        Assert.Equal(11, lowestPrimes[11]);
    }
}
