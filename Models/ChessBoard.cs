using System.Collections.Generic;
using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace ChessWithCohorts.Models
{
    public class ChessBoard
    {
        private const int BOARD_SIZE = 8;
        private Dictionary<Location, Square> SquareMap;
        public int Size
        {
            get => BOARD_SIZE;
        }

        [JsonIgnore]
        public Dictionary<Location, Square> Map
        {
            get => SquareMap;
        }

        private Square[,] squares = new Square[BOARD_SIZE, BOARD_SIZE];

        public Square[,] BoardSquares
        {
            get => squares;
        }

        public ChessBoard()
        {
            SquareMap = new Dictionary<Location,Square>();

            for (int i=0; i < BOARD_SIZE; i++)
            {
                int column = 0;
                SquareColor CurrentColor = (i % 2 == 0) ? SquareColor.LIGHT : SquareColor.DARK;
                foreach (GameFile f in Enum.GetValues(typeof(GameFile)))
                {
                    Square NewSquare = new Square(new Location(f, BOARD_SIZE - i), CurrentColor);
                    SquareMap.Add(NewSquare.Location, NewSquare);
                    squares[i,column] = NewSquare;
                    Console.WriteLine($"{NewSquare.Location.File}, {NewSquare.Location.Rank} - {NewSquare.Color} : {i},{column}");
                    CurrentColor = (CurrentColor == SquareColor.DARK) ? SquareColor.LIGHT : SquareColor.DARK;
                    column++;
                }
            }
        }

        public void PlacePiece(ChessPiece piece, Location location)
        {
            // Console.WriteLine(piece);
            // Square PrevSquare = new Square();
            foreach(KeyValuePair<Location, Square> s in this.Map)
            {
                // Console.WriteLine(piece.CurrentLocation);
                // if (piece.CurrentLocation.Equals(s.Key))
                //     PrevSquare = s.Value;

                if (location.Equals(s.Key))
                {
                    Console.WriteLine($"Placed: {piece.Color} {piece.Type}");
                    s.Value.CurrentPiece = piece;
                    s.Value.IsOccupied = true;
                    piece.CurrentLocation = s.Value.Location;
                    // Console.WriteLine(piece.CurrentLocation.File);
                    // PrevSquare.Reset();
                }
            }
        }
    }
}