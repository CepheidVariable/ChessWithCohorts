using System.Collections.Generic;
using System;

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
            List<Location> PossibleMoves = new List<Location>();
            Dictionary<Location, Square> Map = board.Map;
            Location l = this.CurrentLocation;
            FileCandidate(PossibleMoves, Map, l, -1);
            FileCandidate(PossibleMoves, Map, l, 1);
            RankCandidate(PossibleMoves, Map, l, -1);
            RankCandidate(PossibleMoves, Map, l , 1);
            return PossibleMoves;
        }

        private void RankCandidate(List<Location> PossibleMoves, Dictionary<Location, Square> Map, Location l, int offset)
        {
            Location next = LocationFactory.Build(l, 0, offset);

            while (next != null)
            {
                KeyValuePair<Location, Square> m = new KeyValuePair<Location, Square>();
                foreach (KeyValuePair<Location, Square> SquareInstance in Map)
                {
                    if (next.Equals(SquareInstance.Key))
                        m = SquareInstance;
                }
                
                if(m.Key != null)
                {
                    if (Map[m.Key].IsOccupied)
                    {
                        Console.WriteLine("hit piece");
                        if (Map[m.Key].CurrentPiece.Color == this.Color)
                            break;
                        PossibleMoves.Add(next);
                        break;
                    }

                    PossibleMoves.Add(next);
                }

                next = LocationFactory.Build(next, 0, offset);
            }
        }

        private void FileCandidate(List<Location> PossibleMoves, Dictionary<Location, Square> Map, Location l, int offset)
        {
            Location next = LocationFactory.Build(l, offset, 0);
            while (next != null)
            {
                KeyValuePair<Location, Square> m = new KeyValuePair<Location, Square>();
                foreach (KeyValuePair<Location, Square> SquareInstance in Map)
                {
                    if (next.Equals(SquareInstance.Key))
                        m = SquareInstance;
                }
                
                if(m.Key != null)
                {
                    if (Map[m.Key].IsOccupied)
                    {
                        Console.WriteLine("hit piece");
                        // Console.WriteLine($"{m}, {m.Key}");
                        // Console.WriteLine($"{Map[m.Key].IsOccupied}, {Map[m.Key].CurrentPiece}");
                        // Console.WriteLine($"{this.Color}");
                        if (Map[m.Key].CurrentPiece.Color == this.Color)
                            break;
                        PossibleMoves.Add(next);
                        break;
                    }

                    PossibleMoves.Add(next);
                }

                next = LocationFactory.Build(next, offset, 0);
            }
        }

        public override List<Location> GetValidMoves(ChessBoard board, Location current)
        {
            return null;
        }
    }
}