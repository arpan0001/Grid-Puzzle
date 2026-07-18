namespace GridPuzzle.Managers
{
    public class ScoreManager
    {
        private int _score;


        public int Score => _score;


        public void AddScore(int amount)
        {
            _score += amount;
        }


        public void Reset()
        {
            _score = 0;
        }
    }
}