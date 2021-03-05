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
            Location l = this.CurrentLocation;
            Console.WriteLine(l.File);
            int direction = 0;
            if (this.Color == PieceColor.WHITE)
                direction = 1;
            else
                direction = -1;

            // first move
            if (IsFirstMove)
                PossibleMoves.Add(LocationFactory.Build(l, 0, 2*direction));

            // normal move
            PossibleMoves.Add(LocationFactory.Build(l, 0, 1*direction));

            // capturing moves
            PossibleMoves.Add(LocationFactory.Build(l, 1*direction, 1*direction));
            PossibleMoves.Add(LocationFactory.Build(l, -1*direction, 1*direction));
            Console.WriteLine(PossibleMoves.Count);
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
            List<Location> OccupiedFileMoves = ValidMoves.Where(m => m.File == l.File && board.Map[m].IsOccupied).ToList();

            return ValidMoves.Where(m => {
                if (m.File == l.File)
                {
                    foreach (Location f in OccupiedFileMoves)
                    {
                        if (m.File == f.File && m.Rank > f.Rank)
                            return false;
                    }
                    if (board.Map[m].IsOccupied)
                        return false;
                }
                else if ((m.File != l.File) && (board.Map[m].IsOccupied))
                    return !(board.Map[m].CurrentPiece.Color == this.Color);
                else if ((m.File != l.File) && !(board.Map[m].IsOccupied))
                    return false;
                return true;
            }).ToList();
        }

        public override List<Location> GetValidMoves(ChessBoard board, Location current)
        {
            return null;
        }
    }
}