using Algorithm.Algebra;
using Xunit;

namespace Algorithm.Tests.Algebra
{
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
    }
}
