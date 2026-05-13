namespace ConnectFour;

public interface IConnectFour
{
    Player GetPlayerAt(int row, int col);
    Player PlayerOnTurn { get; }
    bool IsGameOver { get; }
    Player Winner { get; }

    void Reset(Player playerOnTurn);
    void Drop(int col);
}