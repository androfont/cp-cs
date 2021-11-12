using Algorithm.Algebra;
using Xunit;

namespace Algorithm.Tests.Algebra;

public class FibonacciToolsTests
{
    [Fact]
    public void FibonacciN_BaseCase_Ok()
    {
        // Arrange
        uint n = 0;

        // Act
        var result = FibonacciTools.FibonacciN(n);

        // Assert
        Assert.Equal((0, 1), result);
    }

    [Fact]
    public void FibonacciN_FirstCase_Ok()
    {
        // Arrange
        uint n = 1;

        // Act
        var result = FibonacciTools.FibonacciN(n);

        // Assert
        Assert.Equal((1, 1), result);
    }

    [Fact]
    public void FibonacciN_10thCase_Ok()
    {
        // Arrange
        uint n = 8;

        // Act
        var result = FibonacciTools.FibonacciN(n);

        // Assert
        Assert.Equal((21, 34), result);
    }
}
