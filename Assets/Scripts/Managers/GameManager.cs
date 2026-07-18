using UnityEngine;

using GridPuzzle.Core;
using GridPuzzle.Utilities;
using GridPuzzle.View;

namespace GridPuzzle.Managers
{
    public class GameManager : MonoBehaviour
    {
        [SerializeField]
        private GridRenderer gridRenderer;

        private GameService gameService;

        private void Awake()
        {
            gameService = new GameService();

            gameService.Initialize();

            gridRenderer.Initialize(
                gameService.Grid);
        }

        public void ExecuteMove(Direction direction)
        {
            if (!gameService.ExecuteMove(direction))
                return;

            gridRenderer.Render(
                gameService.Grid);
        }
    }
}