using System.Collections.Generic;
using GridPuzzle.Data;

namespace GridPuzzle.Managers
{
    /// <summary>
    /// Stores game snapshots for the Undo system.
    /// Responsible only for history management.
    /// </summary>
    public class HistoryManager
    {
        private readonly Stack<GameSnapshot> _history = new();

        /// <summary>
        /// Returns true if there is at least one state to restore.
        /// </summary>
        public bool CanUndo => _history.Count > 0;

        /// <summary>
        /// Saves a snapshot to the history stack.
        /// </summary>
        public void Push(GameSnapshot snapshot)
        {
            if (snapshot == null)
                return;

            _history.Push(snapshot);
        }

        /// <summary>
        /// Restores the previous snapshot.
        /// Returns null if no history exists.
        /// </summary>
        public GameSnapshot Pop()
        {
            if (!CanUndo)
                return null;

            return _history.Pop();
        }

        /// <summary>
        /// Removes all saved history.
        /// </summary>
        public void Clear()
        {
            _history.Clear();
        }
    }
}