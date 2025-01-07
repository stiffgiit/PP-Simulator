using Simulator.Maps;
using Simulator;
using System;
using Xunit;

namespace TestSimulator
{
    public class SmallTorusMapTests
    {
        [Fact]
        public void Constructor_ValidSize_ShouldSetSize()
        {
            // Arrange
            int size = 10;
            // Act
            var map = new SmallTorusMap(size);
            // Assert
            Assert.Equal(size, map.Size);
        }

        [Theory]
        [InlineData(4)]  // Niedopuszczalny rozmiar poniżej 5
        [InlineData(21)] // Niedopuszczalny rozmiar powyżej 20
        public void Constructor_InvalidSize_ShouldThrowArgumentOutOfRangeException(int size)
        {
            // Act & Assert
            var exception = Assert.Throws<ArgumentOutOfRangeException>(() => new SmallTorusMap(size));

            
            Assert.Equal("size", exception.ParamName);
            Assert.Contains("Rozmiar mapy musi być w przedziale od 5 do 20.", exception.Message);
        }

        [Theory]
        [InlineData(0, 0, 10, true)]  
        [InlineData(5, 5, 10, true)]  
        [InlineData(10, 10, 10, false)]  
        public void Exist_ShouldReturnCorrectValue(int x, int y, int size, bool expected)
        {
            // Arrange
            var map = new SmallTorusMap(size);
            var point = new Point(x, y);
            // Act
            var result = map.Exist(point);
            // Assert
            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData(5, 5, 10, Direction.Up, 5, 6)]  
        [InlineData(5, 5, 10, Direction.Down, 5, 4)]  
        [InlineData(5, 5, 10, Direction.Left, 4, 5)] 
        [InlineData(5, 5, 10, Direction.Right, 6, 5)]  
        public void Next_ShouldReturnCorrectPosition(int startX, int startY, int size, Direction direction, int expectedX, int expectedY)
        {
            // Arrange
            var map = new SmallTorusMap(size);
            var point = new Point(startX, startY);
            // Act
            var result = map.Next(point, direction);
            // Assert
            Assert.Equal(new Point(expectedX, expectedY), result);
        }

        [Theory]
        [InlineData(5, 5, 10, Direction.Up, 6, 6)] 
        [InlineData(5, 5, 10, Direction.Down, 4, 4)]  
        [InlineData(5, 5, 10, Direction.Left, 4, 6)]  
        [InlineData(5, 5, 10, Direction.Right, 6, 4)]  
        public void NextDiagonal_ShouldReturnCorrectDiagonalPosition(int startX, int startY, int size, Direction direction, int expectedX, int expectedY)
        {
            // Arrange
            var map = new SmallTorusMap(size);
            var point = new Point(startX, startY);
            // Act
            var result = map.NextDiagonal(point, direction);
            // Assert
            Assert.Equal(new Point(expectedX, expectedY), result);
        }
    }
}
