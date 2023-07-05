using ChessGame.ChessBoard;

namespace ChessGame.ChessLayer
{
    internal class ChessPositionFrame
    {
        public char Column { get; set; }
        public int Row { get; set; }
        public ChessPositionFrame(char column, int row)
        {
            Column = column;
            Row = row;
        }
        public Position ConvertToPosition()
        {
            return new Position(8- Row, Column - 'a');
        }
        public override string ToString()
        {
            return $"{Column}{Row}";
        }
    }
}
