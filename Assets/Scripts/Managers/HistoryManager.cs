using System.Collections.Generic;

using GridPuzzle.Data;


namespace GridPuzzle.Managers
{
    public class HistoryManager
    {
        private readonly Stack<GameSnapshot> _history;


        public HistoryManager()
        {
            _history = new Stack<GameSnapshot>();
        }


        public void Push(GameSnapshot snapshot)
        {
            _history.Push(snapshot);
        }


        public bool CanUndo()
        {
            return _history.Count > 0;
        }


        public GameSnapshot Pop()
        {
            if (!CanUndo())
                return null;


            return _history.Pop();
        }


        public void Clear()
        {
            _history.Clear();
        }
    }
}