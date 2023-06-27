using ChessGame.ChessBoard;

namespace ChessGame
{
    internal class Screen
    {
        public static void printChessBoard(Board board)
        {
            for (int rowIndex = 0; rowIndex < board.Row; rowIndex++)
            {
                for (int columnsIndex = 0; columnsIndex < board.Columns; columnsIndex++)
                {
                    if (board.ChessPart(rowIndex, columnsIndex) == null)
                    {
                        Console.Write("- ");
                    } else
                    {
                        Console.Write($"{board.ChessPart(rowIndex, columnsIndex)} ");
                    }
                }
                Console.WriteLine();
            }
        }
    }
}
