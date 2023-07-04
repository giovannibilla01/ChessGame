using ChessGame.ChessBoard.Enum;
using ChessGame.ChessBoard;
using ChessGame.ChessLayer;

namespace ChessGame
{
    internal class Screen
    {
        public static void PrintChessMatch(ChessMatch chessMatch)
        {
            PrintChessBoard(chessMatch.Board);
            Console.WriteLine();
            PrintCapturedParts(chessMatch);
            Console.WriteLine();
            Console.WriteLine($"Shift: {chessMatch.Shift}");
            Console.WriteLine();
            Console.WriteLine($"Waiting for player: {chessMatch.CurrentPlayer}");
            if (chessMatch.Check)
            {
                Console.WriteLine("Check!");
            }
        }
        public static void PrintCapturedParts(ChessMatch chessMatch)
        {
            Console.WriteLine("Captured parts:");
            Console.Write("White: [ ");
            PrintSet(chessMatch.CapturedParts(Color.White));
            Console.Write("]");
            Console.WriteLine();
            Console.Write("Black: [ ");
            ConsoleColor originalColor = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Blue;
            PrintSet(chessMatch.CapturedParts(Color.Black));
            Console.ForegroundColor = originalColor;
            Console.Write("]");
        }
        public static void PrintSet(HashSet<Part> set)
        {
            foreach (Part part in set)
            {
                Console.Write($"{part} ");
            }
        }
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
                if (part.ColorPart == Color.Black)
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
