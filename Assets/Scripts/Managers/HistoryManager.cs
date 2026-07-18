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


        public void SaveState(
            GridData grid,
            int score,
            int moves)
        {
            GameSnapshot snapshot =
                new GameSnapshot(
                    grid.CloneCells(),
                    score,
                    moves);


            _history.Push(snapshot);
        }


        public bool CanUndo()
        {
            return _history.Count > 0;
        }


        public GameSnapshot Undo()
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