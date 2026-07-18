using UnityEngine;

using GridPuzzle.Core;
using GridPuzzle.Utilities;

namespace GridPuzzle.Managers
{
    public class GameManager : MonoBehaviour
    {
        private GameService _gameService;

        private void Awake()
        {
            _gameService = new GameService();

            _gameService.Initialize();
        }

        public void ExecuteMove(Direction direction)
        {
            _gameService.ExecuteMove(direction);

            // UI update will come later.
        }
    }
}