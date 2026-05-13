namespace Bowling;

public class Game
{
    private readonly int[] _rolls = new int[21];
    private int _currentRoll;

    public void Roll(int pins)
    {
        _rolls[_currentRoll++] = pins;
    }

    public void Roll(params int[] rolls)
    {
        foreach (var pins in rolls)
        {
            Roll(pins);
        }
    }

    public int GetScore()
    {
        int score = 0;
        int rollIndex = 0;
        for (var frame=0; frame<10; frame++)
        {
            if (IsStrike(rollIndex))
            {
                score += 10 + StrikeBonus(rollIndex);
                rollIndex++;
            }
            else if (IsSpare(rollIndex))
            {
                score += 10 + SpareBonus(rollIndex);
                rollIndex+=2;
            }
            else
            {
                score += SumOfPinsInFrame(rollIndex);
                rollIndex += 2;
            }
        }
        return score;
    }

    private bool IsSpare(int rollIndex) =>_rolls[rollIndex] + _rolls[rollIndex + 1] == 10; // => ist gleich wie "returns"
    private bool IsStrike(int rollIndex) => _rolls[rollIndex] == 10;
    private int SpareBonus(int rollIndex) => _rolls[rollIndex + 2];
    private int StrikeBonus(int rollIndex) => _rolls[rollIndex + 1] + _rolls[rollIndex +2];
    private int SumOfPinsInFrame(int rollIndex) => _rolls[rollIndex] + _rolls[rollIndex + 1];
}