namespace GridPuzzle.Data
{
    /// <summary>
    /// Represents one logical board cell.
    /// </summary>
    public sealed class GridCell
    {
        public GridPosition Position { get; }

        /// <summary>
        /// The tile currently occupying this cell.
        /// Null means the cell is empty.
        /// </summary>
        public TileData Tile { get; private set; }

        public bool IsEmpty => Tile == null;

        public GridCell(GridPosition position)
        {
            Position = position;
        }

        public void PlaceTile(TileData tile)
        {
            Tile = tile;
        }

        public TileData RemoveTile()
        {
            TileData removed = Tile;
            Tile = null;
            return removed;
        }

        public void Clear()
        {
            Tile = null;
        }
    }
}