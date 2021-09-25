using Algorithm.Algebra;
using Xunit;

namespace Algorithm.Tests.Algebra
{
    public class BinaryExponentiationTests
    {
        [Fact]
        public void IntPow_Pow2Exp_Ok()
        {
            // Arrange
            long n = 2;
            long neg = -2;
            ulong e = 8;

            // Act
            long result = BinaryExponentiation.IntPow(n, e);
            long negResult = BinaryExponentiation.IntPow(neg, e);

            // Assert
            Assert.Equal(256, result);
            Assert.Equal(256, negResult);
        }

        [Fact]
        public void IntPow_EvenExp_Ok()
        {
            // Arrange
            long n = 2;
            long neg = -2;
            ulong e = 10;

            // Act
            long result = BinaryExponentiation.IntPow(n, e);
            long negResult = BinaryExponentiation.IntPow(neg, e);

            // Assert
            Assert.Equal(1024, result);
            Assert.Equal(1024, negResult);
        }

        [Fact]
        public void IntPow_OddExp_Ok()
        {
            // Arrange
            long n = 2;
            long neg = -2;
            ulong e = 11;

            // Act
            long result = BinaryExponentiation.IntPow(n, e);
            long negResult = BinaryExponentiation.IntPow(neg, e);

            // Assert
            Assert.Equal(2048, result);
            Assert.Equal(-2048, negResult);
        }

        [Fact]
        public void IntPowMod_Pow2Exp_Ok()
        {
            // Arrange
            long n = 2;
            long neg = -2;
            ulong e = 8;
            long mod = 18;

            // Act
            long result = BinaryExponentiation.IntPowMod(n, e, mod);
            long negResult = BinaryExponentiation.IntPowMod(neg, e, mod);

            // Assert
            Assert.Equal(4, result);
            Assert.Equal(4, negResult);
        }

        [Fact]
        public void IntPowMod_EvenExp_Ok()
        {
            // Arrange
            long n = 2;
            long neg = -2;
            ulong e = 10;
            long mod = 18;

            // Act
            long result = BinaryExponentiation.IntPowMod(n, e, mod);
            long negResult = BinaryExponentiation.IntPowMod(neg, e, mod);

            // Assert
            Assert.Equal(16, result);
            Assert.Equal(16, negResult);
        }

        [Fact]
        public void IntPowMod_OddExp_Ok()
        {
            // Arrange
            long n = 2;
            long neg = -2;
            ulong e = 11;
            long mod = 18;

            // Act
            long result = BinaryExponentiation.IntPowMod(n, e, mod);
            long negResult = BinaryExponentiation.IntPowMod(neg, e, mod);

            // Assert
            Assert.Equal(14, result);
            Assert.Equal(-14, negResult);
        }
    }
}
