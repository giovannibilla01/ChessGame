using ChessGame.ChessBoard.Exception;

namespace ChessGame.ChessBoard
{
    internal class Board
    {
        public int Row { get; set; }
        public int Columns { get; set; }
        private Part[,] _parts;

        public Board(int row, int columns)
        {
            Row = row;
            Columns = columns;
            _parts = new Part[row, columns];
        }

        public Part ChessPart(int row, int column) 
        {
            return _parts[row, column];
        }

        public Part ChessPart(Position position)
        {
            return _parts[position.Row, position.Column];
        }
        public bool ExistenceOfPart(Position position)
        {
            ValidatePosition(position);
            return ChessPart(position) != null;
        }
        public void PutPart(Part part, Position position)
        {
            if (ExistenceOfPart(position))
            {
                throw new ChessBoardException("There is already a part in this position");
            }
            _parts[position.Row, position.Column] = part;
            part.PositionPart = position;
        }
        public Part RemovePart(Position position)
        {
            if (ChessPart(position) == null)
            {
                return null;
            }
            Part part = ChessPart(position);
            part.PositionPart = null;
            _parts[position.Row, position.Column] = null;
            return part;
        }
        public bool ValidPosition(Position position)
        {
            return position.Row < 0 || position.Row >= Row || position.Column < 0 || position.Column >= Columns ? false : true;
        }

        public void ValidatePosition(Position position)
        {
            if (!ValidPosition(position))
            {
                throw new ChessBoardException("Invalid Position");
            }
        }
    }
}
