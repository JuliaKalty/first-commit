using ConnectFour;

IConnectFour connectFour = new ConnectFourGame(Player.Red);
Console.WriteLine(connectFour);

while (!connectFour.IsGameOver)
{
    Console.Write("command [1 .. 7, (r)estart, (q)uit, (h)elp] > ");
    string? input = Console.ReadLine();

    switch (input)
    {
        case "1": connectFour.Drop(0);                       break;
        case "2": connectFour.Drop(1);                       break;
        case "3": connectFour.Drop(2);                       break;
        case "4": connectFour.Drop(3);                       break;
        case "5": connectFour.Drop(4);                       break;
        case "6": connectFour.Drop(5);                       break;
        case "7": connectFour.Drop(6);                       break;
        case "r": connectFour.Reset(Player.Red);             break;
        case "q": Console.WriteLine("Ok, bye.");             return;
        case "h": PrintHelp();                               break;
        default:  Console.WriteLine("Unknown command");      break;
    }
    Console.WriteLine(connectFour);
}

Console.WriteLine($"GAME OVER - Winner: {connectFour.Winner.ToString().ToUpper()}");

static void PrintHelp()
{
    Console.WriteLine();
    Console.WriteLine("Available commands:");
    Console.WriteLine("-------------------");
    Console.WriteLine("1 .. 7 --> drop disc in column");
    Console.WriteLine("r      --> restart game");
    Console.WriteLine("q      --> quit game");
    Console.WriteLine("h      --> show help");
}
