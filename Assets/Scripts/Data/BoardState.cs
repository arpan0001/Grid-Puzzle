namespace GridPuzzle.Data
{
    /// <summary>
    /// Complete logical game state.
    /// </summary>
    public sealed class BoardState
    {
        public GridModel Grid { get; }

        public int Score { get; set; }

        public int Moves { get; set; }

        public bool GameWon { get; set; }

        public bool GameOver { get; set; }

        public BoardState(int rows, int columns)
        {
            Grid = new GridModel(rows, columns);
        }
    }
}