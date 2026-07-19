using System;
using GridPuzzle.Utilities;

namespace GridPuzzle.Data
{
    
    // Pure logical board.
    // Contains no Unity references.
    // Stores only game state.
    
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

        // Returns the value stored in a cell.
        public int GetValue(int x, int y)
        {
            return _cells[x, y];
        }

        /// Sets the value of a cell.
        
        public void SetValue(int x, int y, int value)
        {
            _cells[x, y] = value;
        }

        // Returns true if the specified cell is empty.
        
        public bool IsCellEmpty(int x, int y)
        {
            return _cells[x, y] == 0;
        }

        // Checks whether coordinates are inside the board.
       
        public bool IsInside(int x, int y)
        {
            return x >= 0 &&
                   x < Width &&
                   y >= 0 &&
                   y < Height;
        }

        
        // Clears the entire board.
        
        public void Clear()
        {
            Array.Clear(_cells, 0, _cells.Length);
        }

        
        /// Returns a deep copy of the board.
        /// Used by the undo system.
        
        public int[,] CloneCells()
        {
            int[,] copy = new int[Width, Height];

            Array.Copy(_cells, copy, _cells.Length);

            return copy;
        }

        
        // Restores a previously saved board state.
        
        public void Restore(int[,] state)
        {
            Array.Copy(state, _cells, _cells.Length);
        }

        
        /// Returns true if there is at least one empty cell.
        
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