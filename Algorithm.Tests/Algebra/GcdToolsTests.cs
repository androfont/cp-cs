using Algorithm.Algebra;
using Xunit;

namespace Algorithm.Tests.Algebra;

public class GcdToolsTests
{
    [Fact]
    public void Gcd_Basic_Ok()
    {
        // Arrange
        int a = 100;
        int b = 8;

        // Act
        int result = GcdTools.Gcd(a, b);

        // Assert
        Assert.Equal(4, result);
    }

    [Fact]
    public void Lcm_Basic_Ok()
    {
        // Arrange
        int a = 100;
        int b = 8;

        // Act
        int result = GcdTools.Lcm(a, b);

        // Assert
        Assert.Equal(200, result);
    }

    [Fact]
    public void GcdExtended_Basic_Ok()
    {
        // Arrange
        int a = 240;
        int b = 46;

        // Act
        int result = GcdTools.GcdExtended(a, b, out int x, out int y);

        // Assert
        Assert.Equal(2, result);
        Assert.Equal(-9, x);
        Assert.Equal(47, y);
    }
}
