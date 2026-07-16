namespace GridPuzzle.Data
{
    /// <summary>
    /// Represents a single logical cell.
    /// </summary>
    public sealed class GridCell
    {
        public GridPosition Position { get; }

        public int Value { get; private set; }

        public bool IsEmpty => Value == 0;

        public GridCell(GridPosition position)
        {
            Position = position;
            Value = 0;
        }

        public void SetValue(int value)
        {
            Value = value;
        }

        public void Clear()
        {
            Value = 0;
        }
    }
}