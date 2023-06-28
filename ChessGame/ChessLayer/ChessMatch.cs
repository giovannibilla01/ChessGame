using ChessGame.ChessBoard;
using ChessGame.ChessBoard.Enum;

namespace ChessGame.ChessLayer
{
    internal class ChessMatch
    {
        public Board Board { get; private set; }
        private int _shift;
        private Color _currentPlayer;
        public bool Finished { get; set; }

        public ChessMatch()
        {
            Board = new Board(8, 8);
            _shift = 1;
            _currentPlayer = Color.White;
            Finished = false;
            PutPartsInGame();
        }

        public void PerformMovement(Position origin, Position destiny)
        {
            Part part = Board.RemovePart(origin);
            part.IncreaseNumberOfMoves();
            Part capturedPart = Board.RemovePart(destiny);
            Board.PutPart(part, destiny);
        }

        private void PutPartsInGame()
        {
            Board.PutPart(new Tower(Board, Color.White), new ChessPositionFrame('c', 1).ConvertToPosition());
            Board.PutPart(new Tower(Board, Color.White), new ChessPositionFrame('c', 2).ConvertToPosition());
        }
    }
}
