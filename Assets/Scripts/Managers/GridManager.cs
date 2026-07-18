using GridPuzzle.Data;
using GridPuzzle.Utilities;

namespace GridPuzzle.Managers
{
    public class GridManager
    {
        private GridData _grid;


        public GridData Grid => _grid;


        public void Initialize()
        {
            _grid = new GridData();
        }


        public void Reset()
        {
            _grid.Clear();
        }
    }
}