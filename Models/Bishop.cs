using System.Collections.Generic;

namespace ChessWithCohorts.Models
{
    public class Bishop : ChessPiece
    {
        public Bishop(PieceColor color) : base(color)
        {
            this.Type = ChessPieceType.Bishop;
        }

        public override List<Location> GetValidMoves(ChessBoard board)
        {
            return null;
        }

        public override List<Location> GetValidMoves(ChessBoard board, Location current)
        {
            return null;
        }
    }
}