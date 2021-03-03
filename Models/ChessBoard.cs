namespace ChessWithCohorts.Models
{
    public class ChessBoard
    {
        private const int MAX_RANK_SIZE = 8;
        private const int MAX_FILE_SIZE = 8;
        public int Size
        {
            get => MAX_FILE_SIZE;
        }

        private Square[,] squares = new Square[MAX_RANK_SIZE, MAX_FILE_SIZE];

        public Square[,] Squares
        {
            get => squares;
        }

        public ChessBoard()
        {
            for (int i=0; i < MAX_RANK_SIZE; i++)
            {
                for (int j=0; j < MAX_FILE_SIZE; j++)
                {
                    squares[i,j] = new Square(i, j);
                }
            }
        }

        public void MoveChessPiece(IChessPiece piece, Move move)
        {
            foreach (Square s in squares)
            {
                if (s.Rank == move.EndingLocation.Rank && s.File == move.EndingLocation.File)
                {
                    if (s.CurrentPiece == null)
                    {
                        s.CurrentPiece = move.Piece;
                        piece.CurrentLocation = move.EndingLocation;
                    }
                }
            }
        }
    }
}