using System.Collections.Generic;

namespace GridPuzzle.Data
{
    /// <summary>
    /// Represents a single row or column extracted from the board.
    /// </summary>
    public sealed class LineData
    {
        public List<TileData> Tiles { get; }

        public LineData()
        {
            Tiles = new List<TileData>();
        }
    }
}