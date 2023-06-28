using ChessGame;
using ChessGame.ChessBoard;
using ChessGame.ChessLayer;
using ChessGame.ChessBoard.Enum;
using ChessGame.ChessBoard.Exception;

try
{
    ChessMatch chessMatch = new ChessMatch();

    while (!chessMatch.Finished)
    {
        Console.Clear();
        Screen.PrintChessBoard(chessMatch.Board);
        Console.Write("Origin: ");
        Position origin = Screen.ReadGamePosition().ConvertToPosition();
        Console.Write("Destiny: ");
        Position destiny = Screen.ReadGamePosition().ConvertToPosition();
        chessMatch.PerformMovement(origin, destiny);
    }
}
catch (ChessBoardException e)
{
    Console.WriteLine(e.Message);
}