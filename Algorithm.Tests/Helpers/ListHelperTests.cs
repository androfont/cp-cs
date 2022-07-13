using Algorithm.Helpers;
using System.Collections.Generic;
using Xunit;

namespace Algorithm.Tests.Helpers
{
    public class ListHelperTests
    {
        [Fact]
        public void ListHelper_Swap_Ok()
        {
            // Arrange
            IList<int> source = new int[] { 1, 2, 3, 4, 5 };

            // Act
            source.Swap(1, 4);
            source.Swap(0, 2);

            // Assert
            Assert.Equal(3, source[0]);
            Assert.Equal(5, source[1]);
            Assert.Equal(1, source[2]);
            Assert.Equal(4, source[3]);
            Assert.Equal(2, source[4]);
        }
    }
}
