using ChessGame.ChessBoard.Enum;
using ChessGame.ChessBoard;


namespace ChessGame.ChessLayer
{
    internal class Tower : Part
    {
        public Tower(Board board, Color color) : base(color, board)
        {
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

            //Position North
            position.SetValues(PositionPart.Row - 1, PositionPart.Column);
            while (BoardPart.ValidPosition(position) && CanMove(position))
            {
                possibleMovesMatrix[position.Row, position.Column] = true;
                if (BoardPart.ChessPart(position) != null && BoardPart.ChessPart(position).ColorPart != ColorPart)
                {
                    break;
                }
                position.Row --;
            }
            //Position South
            position.SetValues(PositionPart.Row + 1, PositionPart.Column);
            while (BoardPart.ValidPosition(position) && CanMove(position))
            {
                possibleMovesMatrix[position.Row, position.Column] = true;
                if (BoardPart.ChessPart(position) != null && BoardPart.ChessPart(position).ColorPart != ColorPart)
                {
                    break;
                }
                position.Row ++;
            }
            //Position East
            position.SetValues(PositionPart.Row, PositionPart.Column + 1);
            while (BoardPart.ValidPosition(position) && CanMove(position))
            {
                possibleMovesMatrix[position.Row, position.Column] = true;
                if (BoardPart.ChessPart(position) != null && BoardPart.ChessPart(position).ColorPart != ColorPart)
                {
                    break;
                }
                position.Column ++;
            }
            //Position West
            position.SetValues(PositionPart.Row, PositionPart.Column - 1);
            while (BoardPart.ValidPosition(position) && CanMove(position))
            {
                possibleMovesMatrix[position.Row, position.Column] = true;
                if (BoardPart.ChessPart(position) != null && BoardPart.ChessPart(position).ColorPart != ColorPart)
                {
                    break;
                }
                position.Column --;
            }
            return possibleMovesMatrix;
        }
        public override string ToString()
        {
            return "T";
        }
    }
}
