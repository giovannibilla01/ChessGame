using ChessGame.ChessBoard.Enum;
using ChessGame.ChessBoard;


namespace ChessGame.ChessLayer
{
    internal class Tower : Part
    {
        public Tower(Board board, Color color) : base(color, board)
        {
        }
        public override string ToString()
        {
            return "T";
        }
    }
}
