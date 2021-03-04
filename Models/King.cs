using System.Collections.Generic;

namespace ChessWithCohorts.Models
{
    public class King : ChessPiece
    {
        public King(PieceColor color) : base(color)
        {
            this.Type = ChessPieceType.King;
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