using System;

namespace ChessWithCohorts.Models
{
    public class Square
    {
        private const int BoardSize = 7;

        private static bool IsInRange(int pos)
        {
            return (pos >= 0) && (pos <= BoardSize);
        }

        public Square(int rank, int file)
        {
            if(!IsInRange(rank))
                throw new ArgumentOutOfRangeException("rank");
            if(!IsInRange(file))
                throw new ArgumentOutOfRangeException("file");

            Rank = rank;
            File = file;
        }

        public int Rank {get; set;}
        public int File {get; set;}
        public IChessPiece CurrentPiece {get; set;}
    }
}