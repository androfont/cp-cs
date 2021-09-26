using Algorithm.Algebra;
using System;
using System.Linq;
using Xunit;

namespace Algorithm.Tests.Algebra
{
    public class LinearDiophantineEquationTests
    {
        [Fact]
        public void CreateInitTest()
        {
            // Arrange
            var lde = new LinearDophantineEquation(5, 4, 19);
            var lde1 = new LinearDophantineEquation(25, 35, 100);
            var lde2 = new LinearDophantineEquation(24, 240, 31);

            // Assert
            Assert.Equal(5, lde.A);
            Assert.Equal(4, lde.B);
            Assert.Equal(19, lde.C);
            Assert.Equal(1, lde.X);
            Assert.Equal(-1, lde.Y);
            Assert.True(lde.HasSolution);

            Assert.Equal(3, lde1.X);
            Assert.Equal(-2, lde1.Y);
            Assert.True(lde1.HasSolution);

            Assert.Equal(1, lde2.X);
            Assert.Equal(0, lde2.Y);
            Assert.False(lde2.HasSolution);
        }

        [Fact]
        public void GetInitialSolutionTest()
        {
            // Arrange
            var lde = new LinearDophantineEquation(25, 35, 100);

            // Act
            var result = lde.GetInitialSolution();

            // Assert
            Assert.Equal(60, result.X);
            Assert.Equal(-40, result.Y);
            Assert.Equal(lde.C, lde.A * result.X + lde.B * result.Y);
        }

        [Fact]
        public void GetInitialSolutionTest_NoSolution()
        {
            // Arrange
            var lde = new LinearDophantineEquation(24, 240, 31);

            // Assert
            Assert.Throws<InvalidOperationException>(() => lde.GetInitialSolution());
        }

        [Fact]
        public void GetSolutionsInRangeTest()
        {
            // Arrange
            var lde = new LinearDophantineEquation(10, 8, 38);

            // Act
            var result = lde.GetSolutionsInRange(0, 100, 0, 100).ToArray();

            // Assert
            Assert.Equal(3, result[0].x);
            Assert.Equal(1, result[0].y);
        }

        [Fact]
        public void MinimizeSolutionSumTest()
        {
            // Arrange
            var lde = new LinearDophantineEquation(10, 8, 38);
            var lde1 = new LinearDophantineEquation(69, 27, 1218);

            // Act
            var result = lde.MinimizeSolutionSum(0, 100, 0, 100);
            var result1 = lde1.MinimizeSolutionSum(0, 100, 0, 100);

            // Assert
            Assert.Equal(3, result.x);
            Assert.Equal(1, result.y);

            Assert.Equal(11, result1.x);
            Assert.Equal(17, result1.y);
        }

        [Fact]
        public void MaximizeSolutionSumTest()
        {
            // Arrange
            var lde = new LinearDophantineEquation(10, 8, 38);
            var lde1 = new LinearDophantineEquation(69, 27, 1218);

            // Act
            var result = lde.MaximizeSolutionSum(0, 100, 0, 100);
            var result1 = lde1.MaximizeSolutionSum(0, 100, 0, 100);

            // Assert
            Assert.Equal(3, result.x);
            Assert.Equal(1, result.y);

            Assert.Equal(2, result1.x);
            Assert.Equal(40, result1.y);
        }

        [Fact]
        public void GetSolutionCountInRangeTest()
        {
            // Arrange
            var lde = new LinearDophantineEquation(69, 27, 1218);

            // Act
            var result = lde.GetSolutionCountInRange(0, 100, 0, 100);

            // Assert
            Assert.Equal(2, result);
        }
    }
}
