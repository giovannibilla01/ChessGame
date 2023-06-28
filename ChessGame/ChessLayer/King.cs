using ChessGame.ChessBoard.Enum;
using ChessGame.ChessBoard;


namespace ChessGame.ChessLayer
{
    internal class King : Part
    {
        public King (Board board, Color color) : base(color, board) 
        { 
        }
        public override string ToString()
        {
            return "K";
        }
    }
}
