namespace GridPuzzle.Data
{
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

        public override bool Equals(object obj)
        {
            if (obj is not GridPosition other)
                return false;

            return Row == other.Row &&
                   Column == other.Column;
        }

        public override int GetHashCode()
        {
            return (Row * 397) ^ Column;
        }

        public static bool operator ==(GridPosition a, GridPosition b)
        {
            return a.Equals(b);
        }

        public static bool operator !=(GridPosition a, GridPosition b)
        {
            return !a.Equals(b);
        }
    }
}