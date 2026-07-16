namespace GridPuzzle.Data
{
    /// <summary>
    /// Represents a logical tile.
    /// This class contains gameplay data only.
    /// It has no Unity dependencies.
    /// </summary>
    public sealed class TileData
    {
        /// <summary>
        /// Current number displayed on the tile.
        /// </summary>
        public int Value { get; private set; }

        public TileData(int value)
        {
            Value = value;
        }

        /// <summary>
        /// Changes the tile value.
        /// </summary>
        public void SetValue(int value)
        {
            Value = value;
        }

        /// <summary>
        /// Doubles the tile value after a merge.
        /// </summary>
        public void DoubleValue()
        {
            Value *= 2;
        }

        public override string ToString()
        {
            return Value.ToString();
        }
    }
}