using GridPuzzle.Data;

namespace GridPuzzle.Gameplay
{
    /// <summary>
    /// Reads rows and columns from the logical board.
    /// </summary>
    public sealed class LineExtractor
    {
        public LineData GetRow(GridModel grid, int row)
        {
            LineData line = new LineData();

            for (int column = 0; column < grid.Columns; column++)
            {
                line.Tiles.Add(
                    grid.GetCell(row, column).Tile);
            }

            return line;
        }

        public LineData GetColumn(GridModel grid, int column)
        {
            LineData line = new LineData();

            for (int row = 0; row < grid.Rows; row++)
            {
                line.Tiles.Add(
                    grid.GetCell(row, column).Tile);
            }

            return line;
        }
    }
}