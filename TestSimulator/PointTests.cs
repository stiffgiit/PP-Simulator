using Simulator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestSimulator;

public class PointTests
{
    [Fact]
    public void Constructor_ShouldSetCoordinatesCorrectly()
    {
        // Arrange
        int x = 5, y = 10;
        // Act
        var point = new Point(x, y);
        // Assert
        Assert.Equal(x, point.X);
        Assert.Equal(y, point.Y);
    }

    [Fact]
    public void Equals_ShouldReturnTrueForEqualPoints()
    {
        // Arrange
        var point1 = new Point(3, 4);
        var point2 = new Point(3, 4);
        // Act & Assert
        Assert.True(point1.Equals(point2));
    }

    [Fact]
    public void Equals_ShouldReturnFalseForDifferentPoints()
    {
        // Arrange
        var point1 = new Point(1, 2);
        var point2 = new Point(2, 1);
        // Act & Assert
        Assert.False(point1.Equals(point2));
    }
}
