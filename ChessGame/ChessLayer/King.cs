using ChessGame.ChessBoard.Enum;
using ChessGame.ChessBoard;


namespace ChessGame.ChessLayer
{
    internal class King : Part
    {
        public King (Board board, Color color) : base(color, board) 
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

            Position position = new Position(0, 0);

            //Position North
            position.SetValues(PositionPart.Row - 1, PositionPart.Column);
            if (BoardPart.ValidPosition(position) && CanMove(position))
            {
                possibleMovesMatrix[position.Row, position.Column] = true;
            }
            //Position North East
            position.SetValues(PositionPart.Row - 1, PositionPart.Column + 1);
            if (BoardPart.ValidPosition(position) && CanMove(position))
            {
                possibleMovesMatrix[position.Row, position.Column] = true;
            }
            //Position East
            position.SetValues(PositionPart.Row, PositionPart.Column + 1);
            if (BoardPart.ValidPosition(position) && CanMove(position))
            {
                possibleMovesMatrix[position.Row, position.Column] = true;
            }
            //Position South East
            position.SetValues(PositionPart.Row + 1, PositionPart.Column + 1);
            if (BoardPart.ValidPosition(position) && CanMove(position))
            {
                possibleMovesMatrix[position.Row, position.Column] = true;
            }
            //Position South
            position.SetValues(PositionPart.Row + 1, PositionPart.Column);
            if (BoardPart.ValidPosition(position) && CanMove(position))
            {
                possibleMovesMatrix[position.Row, position.Column] = true;
            }
            //Position South West
            position.SetValues(PositionPart.Row + 1, PositionPart.Column - 1);
            if (BoardPart.ValidPosition(position) && CanMove(position))
            {
                possibleMovesMatrix[position.Row, position.Column] = true;
            }
            //Position West
            position.SetValues(PositionPart.Row, PositionPart.Column - 1);
            if (BoardPart.ValidPosition(position) && CanMove(position))
            {
                possibleMovesMatrix[position.Row, position.Column] = true;
            }
            //Position North West
            position.SetValues(PositionPart.Row - 1, PositionPart.Column - 1);
            if (BoardPart.ValidPosition(position) && CanMove(position))
            {
                possibleMovesMatrix[position.Row, position.Column] = true;
            }
            return possibleMovesMatrix;
        }
        public override string ToString()
        {
            return "K";
        }
    }
}
