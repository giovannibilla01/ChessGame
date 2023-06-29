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
        Console.WriteLine();
        Console.Write("Origin: ");
        Position origin = Screen.ReadGamePosition().ConvertToPosition();
        bool[,] possiblePositionsMatrix = chessMatch.Board.ChessPart(origin).PossibleMoves();
        Console.Clear();
        Screen.PrintChessBoard(chessMatch.Board, possiblePositionsMatrix);
        Console.WriteLine();
        Console.Write("Destiny: ");
        Position destiny = Screen.ReadGamePosition().ConvertToPosition();
        chessMatch.PerformMovement(origin, destiny);
    }
}
catch (ChessBoardException e)
{
    Console.WriteLine(e.Message);
}