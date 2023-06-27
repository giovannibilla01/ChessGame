namespace ChessGame.ChessBoard
{
    internal class Board
    {
        public int Row { get; set; }
        public int Columns { get; set; }
        private Part[,] _parts;

        public Board(int row, int columns)
        {
            Row = row;
            Columns = columns;
            _parts = new Part[row, columns];
        }

        public Part ChessPart(int row, int column) 
        {
            return _parts[row, column];
        }    
    }
}
