using GridPuzzle.Data;
using GridPuzzle.Utilities;

namespace GridPuzzle.Processors
{
    
    /// Handles tile merging only.
    /// Assumes the board has already been compressed.
    
    public class MergeProcessor
    {
        public MoveResult Merge(GridData grid, Direction direction)
        {
            MoveResult result = new MoveResult();

            bool processRows = direction == Direction.Left || direction == Direction.Right;
            bool reverse = direction == Direction.Right || direction == Direction.Down;

            int lineCount = processRows ? grid.Height : grid.Width;
            int lineLength = processRows ? grid.Width : grid.Height;

            for (int line = 0; line < lineCount; line++)
            {
                MergeLine(grid, line, lineLength, processRows, reverse, ref result);
            }

            return result;
        }

        private void MergeLine( GridData grid,int line,int length, bool isRow,bool reverse,ref MoveResult result)
        {
            int start = reverse ? length - 1 : 0;
            int end = reverse ? 0 : length - 1;
            int step = reverse ? -1 : 1;

            for (int i = start; i != end; i += step)
            {
                int next = i + step;

                int x1 = isRow ? i : line;
                int y1 = isRow ? line : i;

                int x2 = isRow ? next : line;
                int y2 = isRow ? line : next;

                int value = grid.GetValue(x1, y1);

                if (value == 0)
                    continue;

                if (value != grid.GetValue(x2, y2))
                    continue;

                int mergedValue = value * 2;

                grid.SetValue(x1, y1, mergedValue);
                grid.SetValue(x2, y2, 0);

                result.BoardChanged = true;
                result.ScoreGained += mergedValue;

                if (mergedValue >= GameConstants.WinValue)
                    result.HasWon = true;
            }
        }
    }
}