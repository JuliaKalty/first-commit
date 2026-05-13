namespace ConnectFour;

public class ConnectFourGame : IConnectFour
{
    private const int Rows = 6;
    private const int Cols = 7;
    private const int WinLength = 4;

    private readonly Player[,] _board = new Player[Rows, Cols];

    public Player PlayerOnTurn { get; private set; }
    public bool IsGameOver { get; private set; }
    public Player Winner { get; private set; }

    public ConnectFourGame(Player playerOnTurn)
    {
        PlayerOnTurn = playerOnTurn;
    }

    // -------------------------------------------------------------------------
    // GetPlayerAt
    // -------------------------------------------------------------------------

    public Player GetPlayerAt(int row, int col) => _board[row, col];

    // -------------------------------------------------------------------------
    // Drop
    // -------------------------------------------------------------------------

    public void Drop(int col)
    {
        if (col < 0 || col >= Cols)
            throw new ArgumentOutOfRangeException(nameof(col), $"Spalte muss zwischen 0 und {Cols - 1} liegen.");

        if (IsGameOver)
            throw new InvalidOperationException("Das Spiel ist bereits beendet.");

        // Unterste freie Zeile in der Spalte finden
        int row = FindFreeRow(col);
        if (row < 0)
            throw new InvalidOperationException($"Spalte {col} ist bereits voll.");

        _board[row, col] = PlayerOnTurn;

        if (CheckWin(row, col))
        {
            Winner = PlayerOnTurn;
            IsGameOver = true;
        }
        else if (IsBoardFull())
        {
            IsGameOver = true;          // Unentschieden – Winner bleibt None
        }
        else
        {
            // Spieler wechseln
            PlayerOnTurn = PlayerOnTurn == Player.Yellow ? Player.Red : Player.Yellow;
        }
    }

    // -------------------------------------------------------------------------
    // Reset
    // -------------------------------------------------------------------------

    public void Reset(Player playerOnTurn)
    {
        for (int r = 0; r < Rows; r++)
            for (int c = 0; c < Cols; c++)
                _board[r, c] = Player.None;

        PlayerOnTurn = playerOnTurn;
        IsGameOver = false;
        Winner = Player.None;
    }

    // -------------------------------------------------------------------------
    // Hilfsmethoden
    // -------------------------------------------------------------------------

    /// <summary>Gibt die unterste freie Zeile in einer Spalte zurück, oder -1 wenn voll.</summary>
    private int FindFreeRow(int col)
    {
        for (int row = Rows - 1; row >= 0; row--)
            if (_board[row, col] == Player.None)
                return row;
        return -1;
    }

    private bool IsBoardFull()
    {
        for (int c = 0; c < Cols; c++)
            if (_board[0, c] == Player.None)
                return false;
        return true;
    }

    /// <summary>Prüft ob der zuletzt gelegte Stein bei (row, col) einen Sieg ergibt.</summary>
    private bool CheckWin(int row, int col)
    {
        Player p = _board[row, col];

        return CountInDirection(row, col, p, 0, 1) >= WinLength  // horizontal
            || CountInDirection(row, col, p, 1, 0) >= WinLength  // vertikal
            || CountInDirection(row, col, p, 1, 1) >= WinLength  // diagonal  \
            || CountInDirection(row, col, p, 1, -1) >= WinLength; // diagonal  /
    }

    /// <summary>
    /// Zählt zusammenhängende Steine des Spielers <paramref name="p"/>
    /// in beide Richtungen (±dr, ±dc) inklusive dem Startfeld.
    /// </summary>
    private int CountInDirection(int row, int col, Player p, int dr, int dc)
    {
        return 1
             + CountSteps(row, col, p, dr, dc)
             + CountSteps(row, col, p, -dr, -dc);
    }

    private int CountSteps(int row, int col, Player p, int dr, int dc)
    {
        int count = 0;
        int r = row + dr;
        int c = col + dc;

        while (r >= 0 && r < Rows && c >= 0 && c < Cols && _board[r, c] == p)
        {
            count++;
            r += dr;
            c += dc;
        }
        return count;
    }

    // -------------------------------------------------------------------------
    // ToString – Konsolenausgabe
    // -------------------------------------------------------------------------

    public override string ToString()
    {
        var sb = new System.Text.StringBuilder();
        sb.AppendLine("+---+---+---+---+---+---+---+");

        for (int r = 0; r < Rows; r++)
        {
            sb.Append("|");
            for (int c = 0; c < Cols; c++)
            {
                string symbol = _board[r, c] switch
                {
                    Player.Yellow => " Y ",
                    Player.Red => " R ",
                    _ => "   "
                };
                sb.Append(symbol).Append("|");
            }
            sb.AppendLine();
            sb.AppendLine("+---+---+---+---+---+---+---+");
        }

        sb.AppendLine("  1   2   3   4   5   6   7  ");

        if (!IsGameOver)
            sb.AppendLine($"Spieler am Zug: {PlayerOnTurn}");
        else if (Winner != Player.None)
            sb.AppendLine($"GEWINNER: {Winner}!");
        else
            sb.AppendLine("UNENTSCHIEDEN!");

        return sb.ToString();
    }
}
