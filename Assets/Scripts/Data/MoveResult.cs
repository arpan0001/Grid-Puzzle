using System.Collections.Generic;

namespace GridPuzzle.Data
{
    /// <summary>
    /// Contains the result of a move execution.
    /// </summary>
    public sealed class MoveResult
    {
        public bool BoardChanged { get; set; }

        public int ScoreGained { get; set; }

        public List<CellChange> Changes { get; }

        public MoveResult()
        {
            Changes = new List<CellChange>();
        }
    }
}