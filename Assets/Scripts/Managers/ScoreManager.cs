namespace GridPuzzle.Managers
{
    public class ScoreManager
    {
        private int _score;

        public void SetScore(int value)
        {
            _score = value;
        }

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