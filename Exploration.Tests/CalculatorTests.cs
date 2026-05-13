using Xunit;
using FluentAssertions;

namespace Exploration.Tests;

public class CalculatorTests
{
    private readonly Calculator _calculator;

    public CalculatorTests()
    {
        _calculator = new Calculator();
    }

   [Fact]
   public void Calculate_WhenAdd_ReturnsCorrectResult()
    {
        // arrange
        var calculator = _calculator;
        int x = 5;
        int y = 2;
        int expected = 7;

        // act
        var actual = calculator.Add(x,y);

        //assert
        Assert.Equal(expected, actual);
    }

    [Fact]
   public void Calculate_WhenSubtract_ReturnsCorrectResult()
    {
        // arrange
        var calculator = _calculator;
        int x = 5;
        int y = 2;
        int expected = 3;

        // act
        var actual = calculator.Subtract(x,y);

        //assert
        Assert.Equal(expected, actual);
    }

    [Fact]
    public void Calculate_WhenDevidedByZero_ThrowsDivideByZeroException()
    {
        Assert.Throws<DivideByZeroException>(() => _calculator.Divide(10,0));
    }

    [Theory]
    //[InlineData(2,5,10)]
    //[InlineData(3,6,18)]
    [MemberData(nameof(MultiplyTestData))]
    public void Calculate_WhenMultiply_ReturnsCorrectResult(int x, int y, int expected)
    {
        var actual =_calculator.Multiply(x,y);
        //Assert.Equal(expected, actual);
        actual.Should().Be(expected); //FluentAssertions macht das so

    }


    public static TheoryData<int, int, int> MultiplyTestData=>
    new()
    {
        {1,2,2},
        {2,5,10},
        {3,6,18},

    };

}