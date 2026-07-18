using UnityEngine;

using GridPuzzle.Core;
using GridPuzzle.Input;
using GridPuzzle.Utilities;
using GridPuzzle.View;

namespace GridPuzzle.Managers
{
    public class GameManager : MonoBehaviour
    {
        [Header("References")]
        [SerializeField] private InputManager inputManager;
        [SerializeField] private GridRenderer gridRenderer;

        private GameService gameService;

        private void Awake()
        {
            gameService = new GameService();
            gameService.Initialize();

            gridRenderer.Initialize(gameService.Grid);
        }

        private void OnEnable()
        {
            if (inputManager != null)
            {
                inputManager.SwipePerformed += OnSwipe;
            }
        }

        private void OnDisable()
        {
            if (inputManager != null)
            {
                inputManager.SwipePerformed -= OnSwipe;
            }
        }

        private void OnSwipe(Direction direction)
        {
            bool boardChanged = gameService.ExecuteMove(direction);

            if (!boardChanged)
                return;

            gridRenderer.Render(gameService.Grid);

            UpdateUI();
        }

        private void UpdateUI()
        {
            // Phase 9
            // Example:
            //
            // scoreText.text = gameService.Score.ToString();
            // movesText.text = gameService.RemainingMoves.ToString();
        }
    }
}