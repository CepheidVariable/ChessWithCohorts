using System.Collections.Generic;

namespace ChessWithCohorts.Models
{
    public class Pawn : ChessPiece
    {
        public Pawn(PieceColor color) : base(color)
        {
            this.Type = ChessPieceType.Pawn;
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