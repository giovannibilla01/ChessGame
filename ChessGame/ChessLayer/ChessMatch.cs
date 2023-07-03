using ChessGame.ChessBoard;
using ChessGame.ChessBoard.Enum;
using ChessGame.ChessBoard.Exception;

namespace ChessGame.ChessLayer
{
    internal class ChessMatch
    {
        public Board Board { get; private set; }
        public int Shift { get; private set; }
        public Color CurrentPlayer { get; private set; }
        public bool Finished { get; set; }

        public ChessMatch()
        {
            Board = new Board(8, 8);
            Shift = 1;
            CurrentPlayer = Color.White;
            Finished = false;
            PutPartsInGame();
        }

        public void PerformMovement(Position origin, Position destiny)
        {
            Part part = Board.RemovePart(origin);
            part.IncreaseNumberOfMoves();
            Part capturedPart = Board.RemovePart(destiny);
            Board.PutPart(part, destiny);
        }

        public void Play(Position origin, Position destiny)
        {
            PerformMovement(origin, destiny);
            ChangePlayer();
            Shift++;
        }
        public void ValidateOriginPosition(Position position)
        {
            if (Board.ChessPart(position) == null)
            {
                throw new ChessBoardException("There is no part in the chosen origin!");
            }
            if (CurrentPlayer != Board.ChessPart(position).ColorPart)
            {
                throw new ChessBoardException("The chosen piece does not belong to you!");
            }
            if (!Board.ChessPart(position).TherePossibilityToMove())
            {
                throw new ChessBoardException("There are no possible moves for this piece!");
            }
        }
        public void ValidateDestinyPosition(Position origin, Position destiny)
        {
            if (!Board.ChessPart(origin).CanMoveTo(destiny))
            {
                throw new ChessBoardException("Invalid target position!");
            }
        }
        public void ChangePlayer()
        {
            if (CurrentPlayer == Color.White)
            {
                CurrentPlayer = Color.Black;
            } else
            {
                CurrentPlayer = Color.White;
            }
        }

        private void PutPartsInGame()
        {
            Board.PutPart(new Tower(Board, Color.White), new ChessPositionFrame('c', 1).ConvertToPosition());
            Board.PutPart(new Tower(Board, Color.White), new ChessPositionFrame('c', 2).ConvertToPosition());
            Board.PutPart(new King(Board, Color.Black), new ChessPositionFrame('c', 8).ConvertToPosition());
        }
    }
}
