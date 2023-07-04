using ChessGame.ChessBoard.Enum;
using ChessGame.ChessBoard;


namespace ChessGame.ChessLayer
{
    internal class Pawn : Part
    {
        public Pawn(Board board, Color color) : base(color, board)
        {
        }
        public override string ToString()
        {
            return "I";
        }
        private bool EnemyAhead(Position position)
        {
            Part part = BoardPart.ChessPart(position);
            return part != null && part.ColorPart != this.ColorPart;
        }
        private bool FreePosition(Position position)
        {
            return BoardPart.ChessPart(position) == null;
        }
        public override bool[,] PossibleMoves()
        {
            bool[,] possibleMovesMatrix = new bool[BoardPart.Row, BoardPart.Columns];

            Position position = new(0, 0);

            if (ColorPart == Color.White)
            {
                position.SetValues(PositionPart.Row - 1, PositionPart.Column);
                if (BoardPart.ValidPosition(position) && FreePosition(position))
                {
                    possibleMovesMatrix[position.Row, position.Column] = true;
                }
                position.SetValues(PositionPart.Row - 2, PositionPart.Column);
                if (BoardPart.ValidPosition(position) && FreePosition(position) && AmountMove == 0)
                {
                    possibleMovesMatrix[position.Row, position.Column] = true;
                }
                position.SetValues(PositionPart.Row - 1, PositionPart.Column - 1);
                if (BoardPart.ValidPosition(position) && EnemyAhead(position))
                {
                    possibleMovesMatrix[position.Row, position.Column] = true;
                }
                position.SetValues(PositionPart.Row - 1, PositionPart.Column + 1);
                if (BoardPart.ValidPosition(position) && EnemyAhead(position))
                {
                    possibleMovesMatrix[position.Row, position.Column] = true;
                }
            } else
            {
                position.SetValues(PositionPart.Row + 1, PositionPart.Column);
                if (BoardPart.ValidPosition(position) && FreePosition(position))
                {
                    possibleMovesMatrix[position.Row, position.Column] = true;
                }
                position.SetValues(PositionPart.Row + 2, PositionPart.Column);
                if (BoardPart.ValidPosition(position) && FreePosition(position) && AmountMove == 0)
                {
                    possibleMovesMatrix[position.Row, position.Column] = true;
                }
                position.SetValues(PositionPart.Row + 1, PositionPart.Column - 1);
                if (BoardPart.ValidPosition(position) && EnemyAhead(position))
                {
                    possibleMovesMatrix[position.Row, position.Column] = true;
                }
                position.SetValues(PositionPart.Row + 1, PositionPart.Column + 1);
                if (BoardPart.ValidPosition(position) && EnemyAhead(position))
                {
                    possibleMovesMatrix[position.Row, position.Column] = true;
                }
            }
            return possibleMovesMatrix;
        }
    }
}