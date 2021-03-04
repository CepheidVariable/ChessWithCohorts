using System;
using System.Linq;
using System.Collections.Generic;

namespace ChessWithCohorts.Models
{
    public class LocationGenerator
    {
        private static int[] files = Enum.GetValues(typeof(File))
            .Cast<int>()
            .ToArray();

        public static Location build(Location current, int fileOffset, int rankOffset)
        {
            int currentFile = (int) current.File;
            return new Location((File) files[currentFile + fileOffset], current.Rank + rankOffset);
        }
    }
}