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
        try
        {
            Console.Clear();
            Screen.PrintChessMatch(chessMatch);
            
            
            Console.WriteLine();
            Console.Write("Origin: ");
            Position origin = Screen.ReadGamePosition().ConvertToPosition();
            chessMatch.ValidateOriginPosition(origin);

            bool[,] possiblePositionsMatrix = chessMatch.Board.ChessPart(origin).PossibleMoves();
            Console.Clear();
            Screen.PrintChessBoard(chessMatch.Board, possiblePositionsMatrix);
            Console.WriteLine();
            Console.Write("Destiny: ");
            Position destiny = Screen.ReadGamePosition().ConvertToPosition();
            chessMatch.ValidateDestinyPosition(origin, destiny);
            chessMatch.Play(origin, destiny);
        }
        catch (ChessBoardException e)
        {
            Console.WriteLine(e.Message);
            Console.ReadLine();
        }
    }
}
catch (ChessBoardException e)
{
    Console.WriteLine(e.Message);
}