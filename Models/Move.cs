using System.Collections.Generic;
using System;

namespace ChessWithCohorts.Models
{
    public class Move
    {
        public Move()
        {
            Piece = null;
            EndingLocation = null;
        }
        public Move(IChessPiece piece, Square endingLocation)
        {
            Piece = piece ?? throw new ArgumentNullException("piece");
            EndingLocation = endingLocation ?? throw new ArgumentNullException("endingLocation");
        }

        public IChessPiece Piece {get;}
        public Square EndingLocation {get;}
    }
}