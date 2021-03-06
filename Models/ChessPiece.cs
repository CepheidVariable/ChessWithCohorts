using System.Collections.Generic;
using System;

namespace ChessWithCohorts.Models
{
    public abstract class ChessPiece : IMovable
    {
        public ChessPieceType Type {get; protected set;}
        public PieceColor Color {get; protected set;}
        public Location CurrentLocation {get; set;}
        public bool IsDestroyed {get; set;} = false;

        public ChessPiece(PieceColor color)
        {
            this.Color = color;
        }

        public virtual List<Location> GetValidMoves(ChessBoard board) {return null;}

        public virtual List<Location> GetValidMoves(ChessBoard board, Location current) {return null;}

        public void MakeMove(Location newLocation, ChessBoard board)
        {
            foreach(KeyValuePair<Location, Square> s in board.Map)
            {
                if (this.CurrentLocation.Equals(s))
                    s.Value.Reset();
            }
            this.CurrentLocation = newLocation;
        }
    }
}