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
    }
}
