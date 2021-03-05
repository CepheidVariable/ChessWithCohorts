using System;

namespace ChessWithCohorts.Models
{
    public class Square
    {
        // private readonly int BoardSize = 8;
        public SquareColor Color {get; private set;}
        public Location Location {get; private set;}
        public ChessPiece CurrentPiece {get; set;} = null;
        public bool IsOccupied {get; set;} = false;

        public Square(){}

        public Square(Location location, SquareColor color)
        {
            this.Location = location;
            this.Color = color;
        }

        public void Reset()
        {
            this.IsOccupied = false;
            this.CurrentPiece = null;
        }
    }
}