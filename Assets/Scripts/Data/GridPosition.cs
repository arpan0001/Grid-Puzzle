namespace GridPuzzle.Data
{
    /// <summary>
    /// Represents a coordinate on the board.
    /// Immutable for safety.
    /// </summary>
    public readonly struct GridPosition
    {
        public int Row { get; }

        public int Column { get; }

        public GridPosition(int row, int column)
        {
            Row = row;
            Column = column;
        }

        public override string ToString()
        {
            return $"({Row},{Column})";
        }
    }
}