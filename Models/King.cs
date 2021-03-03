using System.Collections.Generic;

namespace ChessWithCohorts.Models
{
    public class King : ChessPiece
    {
        private readonly static int[][] MoveTemplates = new int[][]
        {
            new[] {1, -1},
            new[] {1, 0},
            new[] {1, 1},
            new[] {0, -1},
            new[] {0, 1},
            new[] {-1, -1},
            new[] {-1, 0},
            new[] {-1, 1},
        };

        public King(bool white)
        {
            IsWhite = white;
        }
        public override string Type {get; set;} = "King";
        public override bool IsWhite {get; set;} = true;
        public override bool IsDestroyed {get; set;} = false;
        public override IEnumerable<Move> GetValidMoves(ChessBoard board)
        {
            return ChessMoveUtilities.GetMoves(board, this, 1, MoveTemplates);
        }
    }
}