using System.Collections.Generic;
using System;
using System.Linq;

namespace ChessWithCohorts.Models
{
    internal static class ChessMoveUtilities
    {
        private static bool IsValid(ChessBoard board, Square current, int deltaRank, int deltaFile, out Square location)
        {
            location = null;
            var newRank = current.Rank + deltaRank;
            if((newRank < 0) || (newRank > board.Size)) return false;

            var newFile = current.File + deltaFile;
            if((newFile < 0) || (newFile > board.Size)) return false;

            // location = board.Squares[newRank, newFile];
            // if (location.CurrentPiece == null)
            //     location = new Square(newRank, newFile);
            // else
            //     CapturePiece()
            return true;
        }

        internal static IEnumerable<Move> GetMoves(ChessBoard board, IChessPiece piece, int range, IEnumerable<int[]> mults)
        {
            if (board == null) throw new ArgumentNullException("board");
            if (piece == null) throw new ArgumentNullException("piece");
            if (range < 1) throw new ArgumentOutOfRangeException("range");
            if (mults == null || !mults.Any()) throw new ArgumentException("mults");

            List<Move> PossibleMoves = new List<Move>();

            foreach (var mult in mults)
            {
                for (var radius = 1; radius <= range; radius++)
                {
                    var deltaRank = radius * mult[0];
                    var deltaFile = radius * mult[1];
                    if (IsValid(board, piece.CurrentLocation, deltaRank, deltaFile, out Square newLocation))
                        PossibleMoves.Add(new Move(piece, newLocation));
                    else
                        break;
                }
            }
            return PossibleMoves;
        }
    }
}