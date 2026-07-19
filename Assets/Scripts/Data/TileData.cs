namespace GridPuzzle.Data
{
    
    /// Represents a logical tile.
    /// No rendering information should exist here.
    
    public class TileData
    {
        public int Value { get; private set; }

        public TileData(int value)
        {
            Value = value;
        }

        public void SetValue(int value)
        {
            Value = value;
        }

        public bool IsEmpty => Value == 0;
    }
}