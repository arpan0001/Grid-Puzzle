using System;

namespace GridPuzzle.Data
{
    /// <summary>
    /// Represents a single logical cell change.
    /// Used for Undo and board updates.
    /// </summary>
    [Serializable]
    public sealed class CellChange
    {
        public GridPosition Position { get; }

        public int PreviousValue { get; }

        public int NewValue { get; }

        public CellChange(GridPosition position, int previousValue, int newValue)
        {
            Position = position;
            PreviousValue = previousValue;
            NewValue = newValue;
        }
    }
}