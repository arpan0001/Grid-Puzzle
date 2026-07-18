using GridPuzzle.Data;

namespace GridPuzzle.Processors
{
    public class BombProcessor
    {
        public bool Explode(GridData grid, int centerX, int centerY)
        {
            bool changed = false;

            for (int y = centerY - 1; y <= centerY + 1; y++)
            {
                for (int x = centerX - 1; x <= centerX + 1; x++)
                {
                    if (!grid.IsInside(x, y))
                        continue;

                    if (grid.GetValue(x, y) == 0)
                        continue;

                    grid.SetValue(x, y, 0);

                    changed = true;
                }
            }

            return changed;
        }
    }
}