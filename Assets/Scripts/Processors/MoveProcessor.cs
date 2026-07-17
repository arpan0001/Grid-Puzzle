using GridPuzzle.Data;
using GridPuzzle.Utilities;

namespace GridPuzzle.Processors
{
    /// <summary>
    /// Handles tile movement only.
    /// Does not merge tiles.
    /// </summary>
    public class MoveProcessor
    {
        public bool Move(GridData grid, Direction direction)
        {
            bool moved = false;

            bool processRows = direction == Direction.Left || direction == Direction.Right;
            bool reverse = direction == Direction.Right || direction == Direction.Down;

            int lineCount = processRows ? grid.Height : grid.Width;
            int lineLength = processRows ? grid.Width : grid.Height;

            for (int line = 0; line < lineCount; line++)
            {
                moved |= CompressLine(grid, line, lineLength, processRows, reverse);
            }

            return moved;
        }

        /// <summary>
        /// Compresses a single row or column.
        /// </summary>
        private bool CompressLine(
            GridData grid,
            int line,
            int length,
            bool isRow,
            bool reverse)
        {
            bool moved = false;

            int target = reverse ? length - 1 : 0;

            int start = reverse ? length - 1 : 0;
            int end = reverse ? -1 : length;
            int step = reverse ? -1 : 1;

            for (int i = start; i != end; i += step)
            {
                int x = isRow ? i : line;
                int y = isRow ? line : i;

                int value = grid.GetValue(x, y);

                if (value == 0)
                    continue;

                int targetX = isRow ? target : line;
                int targetY = isRow ? line : target;

                if (i != target)
                {
                    grid.SetValue(targetX, targetY, value);
                    grid.SetValue(x, y, 0);

                    moved = true;
                }

                target += reverse ? -1 : 1;
            }

            return moved;
        }
    }
}

