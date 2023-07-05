using ChessGame.ChessBoard.Enum;

namespace ChessGame.ChessBoard
{
    internal abstract class Part
    {
        public Position PositionPart { get; set; }
        public Color ColorPart { get; protected set; }
        public int AmountMove { get; protected set; }
        public Board BoardPart { get; protected set; }

        public Part (Color colorPart, Board boardPart)
        {
            PositionPart = null;
            ColorPart = colorPart;
            AmountMove = 0;
            BoardPart = boardPart;
        }
        public void IncreaseNumberOfMoves()
        {
            AmountMove++;
        }
        public void DecreaseNumberOfMoves()
        {
            AmountMove--;
        }
        public bool TherePossibilityToMove() 
        {
            bool[,] possibility = PossibleMoves();
            for (int rowIndex = 0; rowIndex < BoardPart.Row; rowIndex++)
            {
                for (int columnIndex = 0; columnIndex < BoardPart.Columns; columnIndex++)
                {
                    if (possibility[rowIndex, columnIndex])
                    {
                        return true;
                    }
                }
            }
            return false;
        }
        public bool PossibleMovement(Position position)
        {
            return PossibleMoves()[position.Row, position.Column];
        }
        public abstract bool[,] PossibleMoves();
    }
}
