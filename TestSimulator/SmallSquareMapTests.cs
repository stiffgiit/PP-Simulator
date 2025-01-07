using Simulator.Maps;
using Simulator;
using System;
using Xunit;

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
        [InlineData(4)]  // Niedopuszczalny rozmiar poniżej 5
        [InlineData(21)] // Niedopuszczalny rozmiar powyżej 20
        public void Constructor_InvalidSize_ShouldThrowArgumentOutOfRangeException(int size)
        {
            // Act & Assert
            Assert.Throws<ArgumentOutOfRangeException>(() => new SmallSquareMap(size));
        }

        [Theory]
        [InlineData(2, 3, 10, true)]  // Punkt wewnątrz mapy
        [InlineData(10, 10, 10, false)]  // Punkt poza mapą (granica)
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

        [Theory]
        [InlineData(5, 5, 10, Direction.Up, 5, 6)]  // Przykład przesunięcia o jeden w górę
        [InlineData(5, 5, 10, Direction.Down, 5, 4)]  // Przesunięcie w dół
        [InlineData(5, 5, 10, Direction.Left, 4, 5)]  // Przesunięcie w lewo
        [InlineData(5, 5, 10, Direction.Right, 6, 5)]  // Przesunięcie w prawo
        public void Next_ShouldReturnCorrectPosition(int startX, int startY, int size, Direction direction, int expectedX, int expectedY)
        {
            // Arrange
            var map = new SmallSquareMap(size);
            var point = new Point(startX, startY);
            // Act
            var result = map.Next(point, direction);
            // Assert
            Assert.Equal(new Point(expectedX, expectedY), result);
        }

        [Theory]
        [InlineData(5, 5, 10, Direction.Up, 6, 6)]  // Przykład przesunięcia po skosie
        [InlineData(5, 5, 10, Direction.Down, 4, 4)]  // Przesunięcie w dół po skosie
        [InlineData(5, 5, 10, Direction.Left, 4, 6)]  // Przesunięcie w lewo po skosie
        [InlineData(5, 5, 10, Direction.Right, 6, 4)]  // Przesunięcie w prawo po skosie
        public void NextDiagonal_ShouldReturnCorrectDiagonalPosition(int startX, int startY, int size, Direction direction, int expectedX, int expectedY)
        {
            // Arrange
            var map = new SmallSquareMap(size);
            var point = new Point(startX, startY);
            // Act
            var result = map.NextDiagonal(point, direction);
            // Assert
            Assert.Equal(new Point(expectedX, expectedY), result);
        }
    }
}
