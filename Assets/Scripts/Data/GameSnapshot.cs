namespace GridPuzzle.Data
{
    public class GameSnapshot
    {
        public readonly int[,] Board;

        public readonly int Score;

        public readonly int RemainingMoves;


        public GameSnapshot(
            int[,] board,
            int score,
            int remainingMoves)
        {
            Board = board;
            Score = score;
            RemainingMoves = remainingMoves;
        }
    }
}