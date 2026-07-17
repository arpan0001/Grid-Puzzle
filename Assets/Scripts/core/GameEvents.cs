using System;
using GridPuzzle.Data;

namespace GridPuzzle.Core
{
    /// <summary>
    /// Central event hub.
    /// Systems communicate only through these events.
    /// </summary>
    public static class GameEvents
    {
        /// <summary>
        /// Raised when the player requests a move.
        /// </summary>
        public static event Action<MoveDirection> MoveRequested;

        /// <summary>
        /// Raised whenever the logical board changes.
        /// </summary>
        public static event Action BoardChanged;

        /// <summary>
        /// Raised whenever the score changes.
        /// </summary>
        public static event Action<int> ScoreChanged;

        /// <summary>
        /// Raised when the player wins.
        /// </summary>
        public static event Action GameWon;

        /// <summary>
        /// Raised when the player loses.
        /// </summary>
        public static event Action GameLost;

        public static void RaiseMoveRequested(MoveDirection direction)
        {
            MoveRequested?.Invoke(direction);
        }

        public static void RaiseBoardChanged()
        {
            BoardChanged?.Invoke();
        }

        public static void RaiseScoreChanged(int score)
        {
            ScoreChanged?.Invoke(score);
        }

        public static void RaiseGameWon()
        {
            GameWon?.Invoke();
        }

        public static void RaiseGameLost()
        {
            GameLost?.Invoke();
        }
    }
}