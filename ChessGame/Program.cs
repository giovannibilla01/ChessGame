using ChessGame;
using ChessGame.ChessBoard;
using ChessGame.ChessLayer;
using ChessGame.ChessBoard.Enum;
using ChessGame.ChessBoard.Exception;

Board chessBoard = new Board(8, 8);

ChessPositionFrame position = new ChessPositionFrame('c', 7);

Console.WriteLine(position);

Console.WriteLine(position.ConvertToPosition());

Screen.printChessBoard(chessBoard);