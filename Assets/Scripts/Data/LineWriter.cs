using GridPuzzle.Data;

namespace GridPuzzle.Gameplay
{
    /// <summary>
    /// Writes processed lines back into the GridModel.
    /// </summary>
    public sealed class LineWriter
    {
        public void WriteRow(GridModel grid, int row, LineData line)
        {
            for (int column = 0; column < grid.Columns; column++)
            {
                GridCell cell = grid.GetCell(row, column);

                if (line.Tiles[column] == null)
                    cell.Clear();
                else
                    cell.PlaceTile(line.Tiles[column]);
            }
        }

        public void WriteColumn(GridModel grid, int column, LineData line)
        {
            for (int row = 0; row < grid.Rows; row++)
            {
                GridCell cell = grid.GetCell(row, column);

                if (line.Tiles[row] == null)
                    cell.Clear();
                else
                    cell.PlaceTile(line.Tiles[row]);
            }
        }
    }
}