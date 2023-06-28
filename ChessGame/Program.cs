using ChessGame;
using ChessGame.ChessBoard;
using ChessGame.ChessLayer;
using ChessGame.ChessBoard.Enum;
using ChessGame.ChessBoard.Exception;

Board chessBoard = new Board(8, 8);

Screen.printChessBoard(chessBoard);

Console.WriteLine();
Console.WriteLine();
try
{
    chessBoard.PutPart(new King(chessBoard, Color.Black), new Position(0, 0));
    chessBoard.PutPart(new Tower(chessBoard, Color.Black), new Position(1, 3));
    chessBoard.PutPart(new Tower(chessBoard, Color.Black), new Position(0, 9));
}
catch (ChessBoardException e)
{
    Console.WriteLine(e.Message);
}

Screen.printChessBoard(chessBoard);