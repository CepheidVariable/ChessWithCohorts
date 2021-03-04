using System.Collections.Generic;

namespace ChessWithCohorts.Models
{
    public interface IMovable
    {
        List<Location> GetValidMoves(ChessBoard board);
        List<Location> GetValidMoves(ChessBoard board, Square square);
        void MakeMove(Square square);
    }
}