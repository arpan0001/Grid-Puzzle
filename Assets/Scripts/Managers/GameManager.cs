using UnityEngine;
using GridPuzzle.Core;
using GridPuzzle.Input;
using GridPuzzle.Utilities;
using GridPuzzle.View;
using GridPuzzle.UI;

namespace GridPuzzle.Managers
{

    // Main controller of the game.It connects Unity objects with the backend game logic (GameService).  
    public class GameManager : MonoBehaviour
    {
        [Header("Scene References")]

       
        [SerializeField] private InputManager inputManager;

       
        [SerializeField] private GridRenderer gridRenderer;

        
        [SerializeField] private UIManager uiManager;

        
        private GameService gameService;

        
        // Called once when the scene starts.
        // Creates and initializes the game.
        
        private void Awake()
        {
           
            gameService = new GameService();

            
            gameService.Initialize();

            
            uiManager.UpdateHUD( gameService.Score,gameService.RemainingMoves, gameService.Combo);

           
            gridRenderer.Initialize(gameService.Grid);
        }

        
        // Subscribe to swipe events.
        // Called whenever this object becomes active.
        
        private void OnEnable()
        {
            if (inputManager != null)
            {
                inputManager.SwipePerformed += OnSwipe;
            }
        }

      
        /// Unsubscribe from swipe events.
        /// Prevents memory leaks and duplicate event calls.
        
        private void OnDisable()
        {
            if (inputManager != null)
            {
                inputManager.SwipePerformed -= OnSwipe;
            }
        }

        
        /// Called whenever the player performs a swipe.
        // Executes one complete game move.
       
        private void OnSwipe(Direction direction)
        {
            
            bool moveExecuted = gameService.ExecuteMove(direction);

           
            if (!moveExecuted)
                return;

            
            gridRenderer.Render(gameService.Grid);

            
            uiManager.UpdateHUD(gameService.Score, gameService.RemainingMoves,gameService.Combo);

            // Check whether the game has ended.
            CheckGameState();
        }


        // Checks if the player has won or if the game is over.
        

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


        /// Starts a completely new game ,Resets the board, score, moves,combo and undo history.
        
        public void RestartGame()
        {
            gameService.Restart();

            
            gridRenderer.Render(gameService.Grid);

           
            uiManager.UpdateHUD(gameService.Score,gameService.RemainingMoves,gameService.Combo);
        }

       
        /// Restores the previous game state.
        public void UndoMove()
        {
            bool restored = gameService.Undo();

            if (!restored)
                return;

            gridRenderer.Render(gameService.Grid);

            
            uiManager.UpdateHUD( gameService.Score,gameService.RemainingMoves, gameService.Combo);
        }

        
        /// Updates only the HUD.
        /// Useful if only score, moves or combo change.
       
        private void UpdateUI()
        {
            uiManager.UpdateHUD(gameService.Score,gameService.RemainingMoves, gameService.Combo);
        }
    }
}