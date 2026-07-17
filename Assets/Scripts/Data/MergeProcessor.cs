using GridPuzzle.Data;

namespace GridPuzzle.Gameplay
{
    /// <summary>
    /// Handles tile merging.
    /// </summary>
    public sealed class MergeProcessor
    {
        public int Merge(LineData line)
        {
            int score = 0;

            for (int i = 0; i < line.Tiles.Count - 1; i++)
            {
                TileData current = line.Tiles[i];
                TileData next = line.Tiles[i + 1];

                if (current == null || next == null)
                    continue;

                if (current.Value != next.Value)
                    continue;

                current.DoubleValue();

                score += current.Value;

                line.Tiles[i + 1] = null;
            }

            return score;
        }
    }
}