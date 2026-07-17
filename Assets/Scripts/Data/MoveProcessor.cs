using GridPuzzle.Core;
using GridPuzzle.Data;

namespace GridPuzzle.Gameplay
{
    public sealed class MoveProcessor
    {
        private readonly LineExtractor extractor;
        private readonly LineCompressor compressor;
        private readonly MergeProcessor merger;
        private readonly LineWriter writer;

        public MoveProcessor()
        {
            extractor = new LineExtractor();
            compressor = new LineCompressor();
            merger = new MergeProcessor();
            writer = new LineWriter();
        }

        public void MoveLeft(BoardState board)
        {
            for (int row = 0; row < board.Grid.Rows; row++)
            {
                LineData line = extractor.GetRow(board.Grid, row);

                compressor.Compress(line, board.Grid.Columns);

                int score = merger.Merge(line);

                compressor.Compress(line, board.Grid.Columns);

                writer.WriteRow(board.Grid, row, line);

                board.Score += score;
            }

            GameEvents.RaiseBoardChanged();
            GameEvents.RaiseScoreChanged(board.Score);
        }
    }
}