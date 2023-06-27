using ChessGame.ChessBoard.Enum;

namespace ChessGame.ChessBoard
{
    internal class Part
    {
        public Position PositionPart { get; set; }
        public Color ColorPart { get; protected set; }
        public int AmountMove { get; protected set; }
        public Board BoardPart { get; protected set; }

        public Part (Position positionPart, Color colorPart, Board boardPart)
        {
            PositionPart = positionPart;
            ColorPart = colorPart;
            AmountMove = 0;
            BoardPart = boardPart;
        }
    }
}
