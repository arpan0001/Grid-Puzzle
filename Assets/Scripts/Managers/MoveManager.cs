using GridPuzzle.Utilities;

namespace GridPuzzle.Managers
{
    public class MoveManager
    {
        private int _remainingMoves;

        public int RemainingMoves => _remainingMoves;

        public MoveManager()
        {
            Reset();
        }

        public void ConsumeMove()
        {
            if (_remainingMoves > 0)
                _remainingMoves--;
        }

        public void SetMoves(int moves)
        {
            _remainingMoves = moves;
        }

        public void Reset()
        {
            _remainingMoves = GameConstants.InitialMoves;
        }
    }
}