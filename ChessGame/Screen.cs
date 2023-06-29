using ChessGame.ChessBoard;
using ChessGame.ChessLayer;

namespace ChessGame
{
    internal class Screen
    {
        public static void PrintChessBoard(Board board)
        {
            for (int rowIndex = 0; rowIndex < board.Row; rowIndex++)
            {
                Console.Write($"{8-rowIndex} ");
                for (int columnsIndex = 0; columnsIndex < board.Columns; columnsIndex++)
                {
                    PrintPart(board.ChessPart(rowIndex, columnsIndex));
                }
                Console.WriteLine();
            }
            Console.WriteLine("  A B C D E F G H");
        }
        public static void PrintChessBoard(Board board, bool[,] possiblePositionsMatrix)
        {
            ConsoleColor originalBackground = Console.BackgroundColor;
            ConsoleColor alternativeBackground = ConsoleColor.DarkGray;
            for (int rowIndex = 0; rowIndex < board.Row; rowIndex++)
            {
                Console.Write($"{8 - rowIndex} ");
                for (int columnsIndex = 0; columnsIndex < board.Columns; columnsIndex++)
                {
                    if (possiblePositionsMatrix[rowIndex, columnsIndex])
                    {
                        Console.BackgroundColor = alternativeBackground;
                    } else
                    {
                        Console.BackgroundColor = originalBackground;
                    }
                    PrintPart(board.ChessPart(rowIndex, columnsIndex));
                    Console.BackgroundColor = originalBackground;
                }
                Console.WriteLine();
            }
            Console.WriteLine("  A B C D E F G H");
        }
        public static ChessPositionFrame ReadGamePosition()
        {
            string inputCommand = Console.ReadLine();
            char column = inputCommand[0];
            int row = int.Parse($"{inputCommand[1]}");
            return new ChessPositionFrame(column, row);
        }
        public static void PrintPart(Part part)
        {
            if (part == null)
            {
                Console.Write("- ");
            }
            else
            {
                if (part.ColorPart == ChessBoard.Enum.Color.Black)
                {
                    ConsoleColor systemColorOriginal = Console.ForegroundColor;
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.Write($"{part} ");
                    Console.ForegroundColor = systemColorOriginal;
                }
                else
                {
                    Console.Write($"{part} ");
                }
            }
        }
    }
}
