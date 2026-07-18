using GridPuzzle.Data;
using GridPuzzle.Utilities;

namespace GridPuzzle.Managers
{
    public class GoldenTileManager
    {
        private GridPosition? _goldenTile;

        public bool HasGoldenTile => _goldenTile.HasValue;

        public GridPosition? GoldenTile => _goldenTile;

        public void Clear()
        {
            _goldenTile = null;
        }

        public void SetGoldenTile(GridPosition position)
        {
            _goldenTile = position;
        }

        public bool IsGolden(int x, int y)
        {
            if (!_goldenTile.HasValue)
                return false;

            return _goldenTile.Value.X == x &&
                   _goldenTile.Value.Y == y;
        }

        public void RemoveGoldenTile()
        {
            _goldenTile = null;
        }
    }
}