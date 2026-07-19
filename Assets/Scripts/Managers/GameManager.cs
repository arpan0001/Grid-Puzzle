using UnityEngine;

using GridPuzzle.Core;
using GridPuzzle.Input;
using GridPuzzle.Utilities;
using GridPuzzle.View;
using GridPuzzle.UI;

namespace GridPuzzle.Managers
{
    public class GameManager : MonoBehaviour
    {
        [Header("References")]
        [SerializeField] private InputManager inputManager;
        [SerializeField] private GridRenderer gridRenderer;
        [SerializeField] private UIManager uiManager;


        private GameService gameService;

        private void Awake()
        {
            gameService = new GameService();
            gameService.Initialize();
            uiManager.UpdateHUD(gameService.Score,gameService.RemainingMoves, gameService.Combo);
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
            if (!gameService.ExecuteMove(direction))
                return;

            gridRenderer.Render(gameService.Grid);

            uiManager.UpdateHUD(
                gameService.Score,
                gameService.RemainingMoves, gameService.Combo);

            CheckGameState();
        }
        private void CheckGameState()
        {
            if (gameService.HasWon)
            {
                uiManager.ShowWin();
                return;
            }

            if (gameService.IsGameOver)
            {
                uiManager.ShowGameOver();
            }
        }

        public void RestartGame()
        {
            gameService.Restart();

            gridRenderer.Render(gameService.Grid);

            uiManager.UpdateHUD(
                gameService.Score,
                gameService.RemainingMoves,
                gameService.Combo);
        }

        public void UndoMove()
        {
            bool restored =
                gameService.Undo();


            if (!restored)
                return;


            gridRenderer.Render(
                gameService.Grid);


            uiManager.UpdateHUD(
                gameService.Score,
                gameService.RemainingMoves, gameService.Combo);
        }


        private void UpdateUI()
        {
            // Phase 9
            // Example:
            uiManager.UpdateHUD(gameService.Score, gameService.RemainingMoves, gameService.Combo);
            //
            // scoreText.text = gameService.Score.ToString();
            // movesText.text = gameService.RemainingMoves.ToString();
        }
    }
}