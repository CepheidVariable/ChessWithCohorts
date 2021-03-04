using System.Collections.Generic;
using System;

namespace ChessWithCohorts.Models
{
    public abstract class ChessPiece : IMovable
    {
        public ChessPieceType Type {get; protected set;}
        public PieceColor Color {get; protected set;}
        public Square CurrentSquare {get; set;}
        public bool IsDestroyed {get; set;} = false;

        public ChessPiece(PieceColor color)
        {
            this.Color = color;
        }

        public virtual List<Location> GetValidMoves(ChessBoard board) {return null;}

        public virtual List<Location> GetValidMoves(ChessBoard board, Square square) {return null;}

        public void MakeMove(Square newSquare)
        {
            Square current = this.CurrentSquare;
            this.CurrentSquare = newSquare;
            current.Reset();
        }
    }
}