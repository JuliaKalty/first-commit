namespace Bowling.Tests;
using Xunit;
using FluentAssertions;

public class GameTests
{
    //[Fact]
    //void TestCreateGame()
    //{
    //    //var sut = new Game(); // sut = System Under Test
    //}

    private readonly Game sut;

    public GameTests()
    {
        sut = new Game();
    }

    private void RollMany(int n, int pins)
    {
        for (int i = 0; i < n; i++)
        {
            sut.Roll(pins);
        }
    }

    [Fact]
    void TestRollBall()
    {
        sut.Roll(0);
        
    }

    [Fact]
    void TestGutterGame()
    {
        RollMany(20, 0);
        var result = sut.GetScore();

        result.Should().Be(0);
    }

    [Fact]
    void TestAllOnes()
    {
        RollMany(20,1);
        var result = sut.GetScore();

        result.Should().Be(20);
    }

    [Fact]
    void TestOneSpare()
    {
        sut.Roll(5, 5, 3);
        RollMany(17, 0);
        var result = sut.GetScore();
        result.Should().Be(16);
    }

    [Fact]
    void TestOneStrike()
    {
        sut.Roll(10, 5,3, 0,0, 0,0, 0,0, 0,0, 0,0, 0,0, 0,0, 0,0);
        
        var result = sut.GetScore();
        result.Should().Be(26);
    }

    [Fact]
    void TestPerfectGame()
    {
        RollMany(12, 10);
        var result = sut.GetScore();
        result.Should().Be(300);
    }

    [Fact]
    void AcceptanceTest()
    {
        sut.Roll(1,4, 4,5, 6,4, 5,5, 10, 0,1, 7,3, 6,4, 10, 2,8,6);
        var result = sut.GetScore();
        result.Should().Be(133);
    }
}