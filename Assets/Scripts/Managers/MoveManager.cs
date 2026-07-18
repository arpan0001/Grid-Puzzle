namespace GridPuzzle.Managers
{
    public class MoveManager
    {
        private int _remainingMoves;


        public int RemainingMoves =>
            _remainingMoves;

        public void SetMoves(int value)
        {
            _remainingMoves = value;
        }


        public void Initialize(int moves)
        {
            _remainingMoves = moves;
        }


        public bool ConsumeMove()
        {
            if (_remainingMoves <= 0)
                return false;


            _remainingMoves--;

            return true;
        }


        public void Reset(int moves)
        {
            _remainingMoves = moves;
        }
    }
}