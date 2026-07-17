using GridPuzzle.Data;

namespace GridPuzzle.Gameplay
{
    /// <summary>
    /// Removes empty spaces from a line.
    /// </summary>
    public sealed class LineCompressor
    {
        public void Compress(LineData line, int length)
        {
            line.Tiles.RemoveAll(tile => tile == null);

            while (line.Tiles.Count < length)
            {
                line.Tiles.Add(null);
            }
        }
    }
}