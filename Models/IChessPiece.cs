using System.Collections.Generic;

namespace ChessWithCohorts.Models
{
    public interface IChessPiece
    {
        Square CurrentLocation {get; set;}
        string Type {get;}
        bool IsWhite {get; set;}
        bool IsDestroyed {get; set;}
        IEnumerable<Move> GetValidMoves(ChessBoard board);
    }
}