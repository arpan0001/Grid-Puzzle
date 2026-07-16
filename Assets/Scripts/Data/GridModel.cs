using System;

namespace GridPuzzle.Data
{
    public sealed class GridModel
    {
        private readonly GridCell[,] cells;

        public int Rows { get; }

        public int Columns { get; }

        public GridModel(int rows, int columns)
        {
            if (rows <= 0)
                throw new ArgumentOutOfRangeException(nameof(rows));

            if (columns <= 0)
                throw new ArgumentOutOfRangeException(nameof(columns));

            Rows = rows;
            Columns = columns;

            cells = new GridCell[Rows, Columns];

            Initialize();
        }

        private void Initialize()
        {
            for (int row = 0; row < Rows; row++)
            {
                for (int column = 0; column < Columns; column++)
                {
                    cells[row, column] =
                        new GridCell(
                            new GridPosition(row, column));
                }
            }
        }

        public GridCell GetCell(int row, int column)
        {
            if (!IsInside(row, column))
                throw new IndexOutOfRangeException();

            return cells[row, column];
        }

        public bool IsInside(int row, int column)
        {
            return row >= 0 &&
                   row < Rows &&
                   column >= 0 &&
                   column < Columns;
        }
    }
}