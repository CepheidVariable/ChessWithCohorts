using System.Collections.Generic;
using System;
using System.Linq;

namespace ChessWithCohorts.Models
{
    public class Queen : ChessPiece
    {
        private IMovable Bishop;
        private IMovable Rook;

        public Queen(PieceColor color) : base(color)
        {
            this.Type = ChessPieceType.Queen;
        }

        public Queen(PieceColor color, IMovable bishop, IMovable rook) : base(color)
        {
            this.Bishop = bishop;
            this.Rook = rook;
        }

        public override List<Location> GetValidMoves(ChessBoard board)
        {
            List<Location> PossibleMoves = new List<Location>();
            PossibleMoves.AddRange(Bishop.GetValidMoves(board, this.CurrentLocation));
            PossibleMoves.AddRange(Rook.GetValidMoves(board, this.CurrentLocation));
            return PossibleMoves;
        }
        
        public override List<Location> GetValidMoves(ChessBoard board, Location current)
        {
            return null;
        }
    }
}