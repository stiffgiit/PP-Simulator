using Simulator.Maps;
using Simulator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestSimulator
{
    public class SmallSquareMapTests
    {
        [Fact]
        public void Constructor_ValidSize_ShouldSetSize()
        {
            // Arrange
            int size = 15;
            // Act
            var map = new SmallSquareMap(size);
            // Assert
            Assert.Equal(size, map.Size);
        }

        [Theory]
        [InlineData(4)]
        [InlineData(21)]
        public void Constructor_InvalidSize_ShouldThrowArgumentOutOfRangeException(int size)
        {
            // Act & Assert
            Assert.Throws<ArgumentOutOfRangeException>(() => new SmallSquareMap(size));
        }

        [Theory]
        [InlineData(2, 3, 10, true)]
        [InlineData(10, 10, 10, false)]
        public void Exist_ShouldReturnCorrectValue(int x, int y, int size, bool expected)
        {
            // Arrange
            var map = new SmallSquareMap(size);
            var point = new Point(x, y);
            // Act
            var result = map.Exist(point);
            // Assert
            Assert.Equal(expected, result);
        }
    }
}
