using System;

namespace ChessWithCohorts.Models
{
    public class Square
    {
        // private readonly int BoardSize = 8;
        public SquareColor Color {get; private set;}
        public Location Location {get; private set;}
        public ChessPiece CurrentPiece {get; set;} = null;
        public bool isOccupied {get; private set;} = false;


        public Square(Location location, SquareColor color)
        {
            this.Location = location;
            this.Color = color;
        }

        public void Reset()
        {
            this.isOccupied = false;
            this.CurrentPiece = null;
        }
    }
}