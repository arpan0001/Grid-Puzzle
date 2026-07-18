using System;
using GridPuzzle.Utilities;

namespace GridPuzzle.Data
{
    /// <summary>
    /// Pure logical board.
    /// Contains no Unity references.
    /// Stores only game state.
    /// </summary>
    public class GridData
    {
        private readonly int[,] _cells;

        public int Width { get; }

        public int Height { get; }

        public int CellCount => Width * Height;

        public GridData(int width, int height)
        {
            Width = width;
            Height = height;

            _cells = new int[width, height];
        }

        /// <summary>
        /// Returns the value stored in a cell.
        /// </summary>
        public int GetValue(int x, int y)
        {
            return _cells[x, y];
        }

        /// <summary>
        /// Sets the value of a cell.
        /// </summary>
        public void SetValue(int x, int y, int value)
        {
            _cells[x, y] = value;
        }

        /// <summary>
        /// Returns true if the specified cell is empty.
        /// </summary>
        public bool IsCellEmpty(int x, int y)
        {
            return _cells[x, y] == 0;
        }

        /// <summary>
        /// Checks whether coordinates are inside the board.
        /// </summary>
        public bool IsInside(int x, int y)
        {
            return x >= 0 &&
                   x < Width &&
                   y >= 0 &&
                   y < Height;
        }

        /// <summary>
        /// Clears the entire board.
        /// </summary>
        public void Clear()
        {
            Array.Clear(_cells, 0, _cells.Length);
        }

        /// <summary>
        /// Returns a deep copy of the board.
        /// Used by the undo system.
        /// </summary>
        public int[,] CloneCells()
        {
            int[,] copy = new int[Width, Height];

            Array.Copy(_cells, copy, _cells.Length);

            return copy;
        }

        /// <summary>
        /// Restores a previously saved board state.
        /// </summary>
        public void Restore(int[,] state)
        {
            Array.Copy(state, _cells, _cells.Length);
        }

        /// <summary>
        /// Returns true if there is at least one empty cell.
        /// </summary>
        public bool HasEmptyCell()
        {
            for (int y = 0; y < Height; y++)
            {
                for (int x = 0; x < Width; x++)
                {
                    if (_cells[x, y] == 0)
                        return true;
                }
            }

            return false;
        }
    }
}