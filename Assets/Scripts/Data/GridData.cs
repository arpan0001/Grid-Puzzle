using GridPuzzle.Utilities;

namespace GridPuzzle.Data
{
    /// <summary>
    /// Pure logical board.
    /// Contains no Unity references.
    /// </summary>
    public class GridData
    {
        private readonly int[,] _cells;

        public int Width { get; }

        public int Height { get; }

        public GridData()
        {
            Width = GameConstants.GridWidth;
            Height = GameConstants.GridHeight;

            _cells = new int[Width, Height];
        }

        public int GetValue(int x, int y)
        {
            return _cells[x, y];
        }

        public int CellCount
        {
            get
            {
                return Width * Height;
            }
        }


        public void SetValue(int x, int y, int value)
        {
            _cells[x, y] = value;
        }

        public bool IsCellEmpty(int x, int y)
        {
            return _cells[x, y] == 0;
        }
        public bool IsInside(int x, int y)
        {
            return x >= 0 &&
                   x < Width &&
                   y >= 0 &&
                   y < Height;
        }

        public void Clear()
        {
            for (int x = 0; x < Width; x++)
            {
                for (int y = 0; y < Height; y++)
                {
                    _cells[x, y] = 0;
                }
            }
        }

        public int[,] CloneCells()
        {
            return (int[,])_cells.Clone();
        }

        public void Restore(int[,] state)
        {
            for (int x = 0; x < Width; x++)
            {
                for (int y = 0; y < Height; y++)
                {
                    _cells[x, y] = state[x, y];
                }
            }
        }

        public bool HasEmptyCell()
        {
            for (int x = 0; x < Width; x++)
            {
                for (int y = 0; y < Height; y++)
                {
                    if (_cells[x, y] == 0)
                        return true;
                }
            }

            return false;
        }
    }
}