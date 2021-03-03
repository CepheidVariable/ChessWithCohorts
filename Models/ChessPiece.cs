using System.Collections.Generic;
using System;

namespace ChessWithCohorts.Models
{
    public abstract class ChessPiece : IChessPiece
    {
        private Square _currentLocation;
        public Square CurrentLocation
        {
            get => _currentLocation;
            set => _currentLocation = value ?? throw new ArgumentNullException();
        }

        public abstract string Type {get; set;}
        public abstract bool IsWhite {get; set;}
        public abstract bool IsDestroyed {get; set;}
        public abstract IEnumerable<Move> GetValidMoves(ChessBoard board);
    }
}