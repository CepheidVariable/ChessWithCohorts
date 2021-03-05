using System;
using System.Linq;
using System.Collections.Generic;

namespace ChessWithCohorts.Models
{
    public class LocationFactory
    {
        private static int[] files = Enum.GetValues(typeof(GameFile))
            .Cast<int>()
            .ToArray();

        public static Location Build(Location current, int fileOffset, int rankOffset)
        {
            int currentFile = (int) current.File;
            if (currentFile + fileOffset < 0 || currentFile + fileOffset > 7)
                return null;    //out of bounds
            if (current.Rank + rankOffset < 1 || current.Rank + rankOffset > 8)
                return null;    //out of bounds
            Console.WriteLine($"{currentFile} + {fileOffset} = {currentFile + fileOffset} | {current.Rank} + {rankOffset} = {current.Rank + rankOffset}");
            return new Location((GameFile) files[currentFile + fileOffset], current.Rank + rankOffset);
        }
    }
}