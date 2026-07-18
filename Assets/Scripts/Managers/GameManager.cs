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
            Debug.Log("GameManager Awake");
            gameService = new GameService();
            gameService.Initialize();
            uiManager.UpdateHUD(gameService.Score,gameService.RemainingMoves);
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
                gameService.RemainingMoves);

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
            gameService.Initialize();

            gridRenderer.Render(gameService.Grid);

            uiManager.HidePanels();

            uiManager.UpdateHUD(
                gameService.Score,
                gameService.RemainingMoves);
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
                gameService.RemainingMoves);
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