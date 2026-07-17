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

            switch (direction)
            {
                case Direction.Left:
                    moved = MoveLeft(grid);
                    break;

                case Direction.Right:
                    moved = MoveRight(grid);
                    break;

                case Direction.Up:
                    moved = MoveUp(grid);
                    break;

                case Direction.Down:
                    moved = MoveDown(grid);
                    break;
            }

            return moved;
        }
        private bool CompressRowLeft(GridData grid, int row)
        {
            bool moved = false;

            int targetX = 0;

            for (int x = 0; x < grid.Width; x++)
            {
                int value = grid.GetValue(x, row);

                if (value == 0)
                    continue;

                if (x != targetX)
                {
                    grid.SetValue(targetX, row, value);
                    grid.SetValue(x, row, 0);

                    moved = true;
                }

                targetX++;
            }

            return moved;
        }

        private bool CompressRowRight(GridData grid, int row)
        {
            bool moved = false;

            int targetX = grid.Width - 1;

            for (int x = grid.Width - 1; x >= 0; x--)
            {
                int value = grid.GetValue(x, row);

                if (value == 0)
                    continue;

                if (x != targetX)
                {
                    grid.SetValue(targetX, row, value);
                    grid.SetValue(x, row, 0);

                    moved = true;
                }

                targetX--;
            }

            return moved;
        }

        private bool CompressColumnUp(GridData grid, int column)
        {
            bool moved = false;

            int targetY = 0;

            for (int y = 0; y < grid.Height; y++)
            {
                int value = grid.GetValue(column, y);

                if (value == 0)
                    continue;

                if (y != targetY)
                {
                    grid.SetValue(column, targetY, value);
                    grid.SetValue(column, y, 0);

                    moved = true;
                }

                targetY++;
            }

            return moved;
        }

        private bool CompressColumnDown(GridData grid, int column)
        {
            bool moved = false;

            int targetY = grid.Height - 1;

            for (int y = grid.Height - 1; y >= 0; y--)
            {
                int value = grid.GetValue(column, y);

                if (value == 0)
                    continue;

                if (y != targetY)
                {
                    grid.SetValue(column, targetY, value);
                    grid.SetValue(column, y, 0);

                    moved = true;
                }

                targetY--;
            }

            return moved;
        }
    


        private bool MoveLeft(GridData grid)
        {
            bool moved = false;

            for (int y = 0; y < grid.Height; y++)
            {
                moved |= CompressRowLeft(grid, y);
            }

            return moved;
        }

        private bool MoveRight(GridData grid)
        {
            bool moved = false;

            for (int y = 0; y < grid.Height; y++)
            {
                moved |= CompressRowRight(grid, y);
            }

            return moved;
        }

        private bool MoveUp(GridData grid)
        {
            bool moved = false;

            for (int x = 0; x < grid.Width; x++)
            {
                moved |= CompressColumnUp(grid, x);
            }

            return moved;
        }

        private bool MoveDown(GridData grid)
        {
            bool moved = false;

            for (int x = 0; x < grid.Width; x++)
            {
                moved |= CompressColumnDown(grid, x);
            }

            return moved;
        }

    }

}