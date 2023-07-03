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
        private HashSet<Part> _parts = new HashSet<Part>();
        private HashSet<Part> _captured = new HashSet<Part>();

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
            if (capturedPart != null)
            {
                _captured.Add(capturedPart);
            }
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
        public HashSet<Part> CapturedParts(Color color)
        {
            HashSet<Part> partsTemporary = new HashSet<Part>();
            foreach (Part part in _captured)
            {
                if (part.ColorPart == color)
                {
                    partsTemporary.Add(part);
                }
            }
            return partsTemporary;
        }
        public HashSet<Part> InGameParts(Color color)
        {
            HashSet<Part> partsTemporary = new HashSet<Part>();
            foreach (Part part in _parts)
            {
                if (part.ColorPart == color)
                {
                    partsTemporary.Add(part);
                }
            }
            partsTemporary.ExceptWith(CapturedParts(color));
            return partsTemporary;
        }
        public void PutNewParts(char column, int row, Part part)
        {
            Board.PutPart(part, new ChessPositionFrame(column, row).ConvertToPosition());
            _parts.Add(part);
        }
        private void PutPartsInGame()
        {
            PutNewParts('c', 1, new Tower(Board, Color.White));
            PutNewParts('c', 2, new Tower(Board, Color.White));
            PutNewParts('d', 2, new Tower(Board, Color.White));
            PutNewParts('e', 2, new Tower(Board, Color.White));
            PutNewParts('e', 1, new Tower(Board, Color.White));
            PutNewParts('d', 1, new King(Board, Color.White));

            PutNewParts('c', 7, new Tower(Board, Color.Black));
            PutNewParts('c', 8, new Tower(Board, Color.Black));
            PutNewParts('d', 7, new Tower(Board, Color.Black));
            PutNewParts('e', 7, new Tower(Board, Color.Black));
            PutNewParts('e', 8, new Tower(Board, Color.Black));
            PutNewParts('d', 8, new King(Board, Color.Black));
        }
    }
}
