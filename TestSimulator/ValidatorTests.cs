using Simulator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestSimulator;

public class ValidatorTests
{
    #region Limiter Tests
    [Theory]
    [InlineData(12, 5, 15, 12)]     
    [InlineData(4, 5, 15, 5)]       
    [InlineData(20, 5, 15, 15)]     
    [InlineData(-7, -15, -5, -7)]   
    [InlineData(-18, -15, -5, -15)] 
    public void Limiter_ReturnsCorrectValue(int value, int min, int max, int expected)
    {
        var result = Validator.Limiter(value, min, max);
        Assert.Equal(expected, result);
    }
    #endregion

    #region Shortener Tests
    [Theory]
    [InlineData("goodbye", 4, 8, '#', "Goodbye")]     
    [InlineData("hi", 4, 8, '*', "Hi**")]           
    [InlineData("this is a long test string", 4, 12, '.', "This is a lo")] 
    [InlineData("hello", 3, 6, '-', "Hello")]          
    [InlineData("xyz", 3, 3, '@', "Xyz")]            
    [InlineData("x", 3, 6, '+', "X++")]             
    [InlineData("", 4, 8, '.', "....")]               
    public void Shortener_ReturnsCorrectString(string value, int min, int max, char placeholder, string expected)
    {
        var result = Validator.Shortener(value, min, max, placeholder);
        Assert.Equal(expected, result);
    }
    #endregion

    #region Edge Case Tests
    [Fact]
    public void Shortener_EmptyStringAndMinLength()
    {
        var result = Validator.Shortener("", 4, 8, '*');
        Assert.Equal("****", result); 
    }

    [Fact]
    public void Shortener_ExactLength()
    {
        var result = Validator.Shortener("Sample", 6, 6, '_');
        Assert.Equal("Sample", result); 
    }

    [Fact]
    public void Limiter_ZeroAndPositiveRange()
    {
        var result = Validator.Limiter(0, 0, 10);
        Assert.Equal(0, result); 
    }

    [Fact]
    public void Limiter_LargeNegativeValue()
    {
        var result = Validator.Limiter(-80, -60, -10);
        Assert.Equal(-60, result); 
    }
    #endregion
}
