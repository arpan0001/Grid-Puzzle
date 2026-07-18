namespace GridPuzzle.Data
{
    public class GameSnapshot
    {
        public readonly int[,] Board;

        public readonly int Score;

        public readonly int RemainingMoves;
        public readonly int Combo;



        public GameSnapshot(
            int[,] board,
            int score,
            int remainingMoves,
            int combo)
        {
            Board = board;
            Score = score;
            RemainingMoves = remainingMoves;
            Combo = combo;
        }
    }
}