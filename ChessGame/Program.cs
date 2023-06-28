using ChessGame;
using ChessGame.ChessBoard;
using ChessGame.ChessLayer;
using ChessGame.ChessBoard.Enum;

Board chessBoard = new Board(8, 8);

Screen.printChessBoard(chessBoard);

Console.WriteLine();
Console.WriteLine();

chessBoard.PutPart(new King(chessBoard, Color.Black) , new Position(0, 0));
chessBoard.PutPart(new Tower(chessBoard, Color.Black), new Position(1, 3));

Screen.printChessBoard(chessBoard);