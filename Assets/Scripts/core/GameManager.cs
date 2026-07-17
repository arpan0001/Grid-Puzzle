using UnityEngine;

namespace GridPuzzle.Core
{
    /// <summary>
    /// Controls the overall game lifecycle.
    /// Does NOT handle gameplay logic.
    /// </summary>
    public class GameManager : MonoBehaviour
    {
        private void Awake()
        {
            Debug.Log("Game Initialized");
        }

        private void Start()
        {
            StartNewGame();
        }

        private void StartNewGame()
        {
            Debug.Log("Starting New Game...");
        }
    }
}