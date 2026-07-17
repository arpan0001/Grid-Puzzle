namespace GridPuzzle.Data
{
    /// <summary>
    /// Stores the complete logical state
    /// required to restore a previous move.
    /// </summary>
    public class GameSnapshot
    {
        public int[,] Board { get; }

        public int Score { get; }

        public int RemainingMoves { get; }

        public GameSnapshot(int[,] board, int score, int remainingMoves)
        {
            Board = board;
            Score = score;
            RemainingMoves = remainingMoves;
        }
    }
}