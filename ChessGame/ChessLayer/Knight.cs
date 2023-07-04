using ChessGame.ChessBoard.Enum;
using ChessGame.ChessBoard;


namespace ChessGame.ChessLayer
{
    internal class Knight : Part
    {
        public Knight(Board board, Color color) : base(color, board)
        {
        }
        public override string ToString()
        {
            return "N";
        }
        private bool CanMove(Position position)
        {
            Part part = BoardPart.ChessPart(position);
            return part == null || part.ColorPart != this.ColorPart;
        }
        public override bool[,] PossibleMoves()
        {
            bool[,] possibleMovesMatrix = new bool[BoardPart.Row, BoardPart.Columns];

            Position position = new(0, 0);

            position.SetValues(PositionPart.Row - 1, PositionPart.Column - 2);
            if (BoardPart.ValidPosition(position) && CanMove(position))
            {
                possibleMovesMatrix[position.Row, position.Column] = true;
            }
            position.SetValues(PositionPart.Row - 2, PositionPart.Column - 1);
            if (BoardPart.ValidPosition(position) && CanMove(position))
            {
                possibleMovesMatrix[position.Row, position.Column] = true;
            }
            position.SetValues(PositionPart.Row - 2, PositionPart.Column + 1);
            if (BoardPart.ValidPosition(position) && CanMove(position))
            {
                possibleMovesMatrix[position.Row, position.Column] = true;
            }
            position.SetValues(PositionPart.Row - 1, PositionPart.Column + 2);
            if (BoardPart.ValidPosition(position) && CanMove(position))
            {
                possibleMovesMatrix[position.Row, position.Column] = true;
            }
            position.SetValues(PositionPart.Row + 1, PositionPart.Column + 2);
            if (BoardPart.ValidPosition(position) && CanMove(position))
            {
                possibleMovesMatrix[position.Row, position.Column] = true;
            }
            position.SetValues(PositionPart.Row + 2, PositionPart.Column + 1);
            if (BoardPart.ValidPosition(position) && CanMove(position))
            {
                possibleMovesMatrix[position.Row, position.Column] = true;
            }
            position.SetValues(PositionPart.Row + 2, PositionPart.Column - 1);
            if (BoardPart.ValidPosition(position) && CanMove(position))
            {
                possibleMovesMatrix[position.Row, position.Column] = true;
            }
            position.SetValues(PositionPart.Row + 1, PositionPart.Column - 2);
            if (BoardPart.ValidPosition(position) && CanMove(position))
            {
                possibleMovesMatrix[position.Row, position.Column] = true;
            }

            return possibleMovesMatrix;
        }
    }
}