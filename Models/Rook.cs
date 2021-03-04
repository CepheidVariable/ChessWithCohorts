using System.Collections.Generic;

namespace ChessWithCohorts.Models
{
    public class Rook : ChessPiece
    {
        public Rook(PieceColor color) : base(color)
        {
            this.Type = ChessPieceType.Rook;
        }

        public override List<Location> GetValidMoves(ChessBoard board)
        {
            return null;
        }

        public override List<Location> GetValidMoves(ChessBoard board, Square square)
        {
            return null;
        }
    }
}