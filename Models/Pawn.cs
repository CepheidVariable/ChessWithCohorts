using System.Collections.Generic;
using System.Linq;
using System;

namespace ChessWithCohorts.Models
{
    public class Pawn : ChessPiece
    {
        private bool IsFirstMove = true;

        public Pawn(PieceColor color) : base(color)
        {
            this.Type = ChessPieceType.Pawn;
        }

        public override List<Location> GetValidMoves(ChessBoard board)
        {
            List<Location> PossibleMoves = new List<Location>();
            Location l = this.CurrentSquare.Location;

            // first move
            if (IsFirstMove)
                PossibleMoves.Add(LocationFactory.Build(l, 0, 2));

            // normal move
            PossibleMoves.Add(LocationFactory.Build(l, 0, 1));

            // capturing moves
            PossibleMoves.Add(LocationFactory.Build(l, 1, 1));
            PossibleMoves.Add(LocationFactory.Build(l, -1, 1));

            PossibleMoves.RemoveAll(n => n == null);

            // Moves based on board dimensions
            List<Location> ValidMoves = new List<Location>();

            for (int i=0; i< PossibleMoves.Count(); i++)
            {
                foreach (KeyValuePair<Location, Square> m in board.Map)
                {
                    if (PossibleMoves[i].Equals(m.Key))
                        ValidMoves.Add(m.Key);
                }
            }

            // Moves based on board condition
            return ValidMoves.Where(m => {
                if ((m.File == l.File) && (board.Map[m].IsOccupied))
                    return false;
                else if ((m.File != l.File) && (board.Map[m].IsOccupied))
                    return !(board.Map[m].CurrentPiece.Color == this.Color);
                else if ((m.File != l.File) && !(board.Map[m].IsOccupied))
                    return false;
                return true;
            }).ToList();
        }

        public override List<Location> GetValidMoves(ChessBoard board, Square square)
        {
            return null;
        }
    }
}