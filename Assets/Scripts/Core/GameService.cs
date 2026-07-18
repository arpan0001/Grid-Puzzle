using GridPuzzle.Data;
using GridPuzzle.Managers;
using GridPuzzle.Processors;
using GridPuzzle.Utilities;

namespace GridPuzzle.Core
{
    public class GameService
    {
        private readonly GridManager _gridManager;
        private readonly MoveProcessor _moveProcessor;
        private readonly MergeProcessor _mergeProcessor;
        private readonly SpawnProcessor _spawnProcessor;
        private readonly ScoreManager _scoreManager;
        private readonly MoveManager _moveManager;
        private readonly HistoryManager _historyManager;

        public GridData Grid => _gridManager.Grid;

        public int Score => _scoreManager.Score;

        public int RemainingMoves => _moveManager.RemainingMoves;

        public GameService()
        {
            _gridManager = new GridManager();
            _moveProcessor = new MoveProcessor();
            _mergeProcessor = new MergeProcessor();
            _spawnProcessor = new SpawnProcessor();
            _scoreManager = new ScoreManager();
            _moveManager = new MoveManager();
            _historyManager = new HistoryManager();
        }

        public void Initialize()
        {
            _gridManager.Initialize();

            _moveManager.Initialize(GameConstants.InitialMoves);

            _spawnProcessor.Spawn(_gridManager.Grid);
            _spawnProcessor.Spawn(_gridManager.Grid);
        }

        public bool ExecuteMove(Direction direction)
        {
            GridData grid = _gridManager.Grid;

            GameSnapshot snapshot = new GameSnapshot(
                grid.CloneCells(),
                _scoreManager.Score,
                _moveManager.RemainingMoves);

            bool moved = _moveProcessor.Move(grid, direction);

            MoveResult mergeResult =
                _mergeProcessor.Merge(grid, direction);

            bool movedAgain =
                _moveProcessor.Move(grid, direction);

            bool boardChanged =
                moved ||
                mergeResult.BoardChanged ||
                movedAgain;

            if (!boardChanged)
                return false;

            _historyManager.Push(snapshot);

            _scoreManager.AddScore(
                mergeResult.ScoreGained);

            _spawnProcessor.Spawn(grid);

            _moveManager.ConsumeMove();

            return true;
        }
    }
}