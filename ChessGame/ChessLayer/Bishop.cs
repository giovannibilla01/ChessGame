using ChessGame.ChessBoard.Enum;
using ChessGame.ChessBoard;


namespace ChessGame.ChessLayer
{
    internal class Bishop : Part
    {
        public Bishop(Board board, Color color) : base(color, board)
        {
        }
        public override string ToString()
        {
            return "B";
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

            position.SetValues(PositionPart.Row -1, PositionPart.Column - 1);
            while (BoardPart.ValidPosition(position) && CanMove(position))
            {
                possibleMovesMatrix[position.Row, position.Column] = true;
                if (BoardPart.ChessPart(position) != null && BoardPart.ChessPart(position).ColorPart != ColorPart)
                {
                    break;
                }
                position.SetValues(position.Row - 1, position.Column - 1);
            }
            
            position.SetValues(PositionPart.Row - 1, PositionPart.Column + 1);
            while (BoardPart.ValidPosition(position) && CanMove(position))
            {
                possibleMovesMatrix[position.Row, position.Column] = true;
                if (BoardPart.ChessPart(position) != null && BoardPart.ChessPart(position).ColorPart != ColorPart)
                {
                    break;
                }
                position.SetValues(position.Row - 1, position.Column + 1);
            }

            position.SetValues(PositionPart.Row + 1, PositionPart.Column + 1);
            while (BoardPart.ValidPosition(position) && CanMove(position))
            {
                possibleMovesMatrix[position.Row, position.Column] = true;
                if (BoardPart.ChessPart(position) != null && BoardPart.ChessPart(position).ColorPart != ColorPart)
                {
                    break;
                }
                position.SetValues(position.Row + 1, position.Column + 1);
            }

            position.SetValues(PositionPart.Row + 1, PositionPart.Column - 1);
            while (BoardPart.ValidPosition(position) && CanMove(position))
            {
                possibleMovesMatrix[position.Row, position.Column] = true;
                if (BoardPart.ChessPart(position) != null && BoardPart.ChessPart(position).ColorPart != ColorPart)
                {
                    break;
                }
                position.SetValues(position.Row + 1, position.Column - 1);
            }

            return possibleMovesMatrix;
        }
    }
}