using UnityEngine;
using GridPuzzle.Data;

namespace GridPuzzle.Core
{
    /// <summary>
    /// Temporary GameManager used to verify that
    /// the board model works correctly.
    /// </summary>
    public class GameManager : MonoBehaviour
    {
        private BoardState boardState;

        private void Start()
        {
            Debug.Log("Creating Board...");

            boardState = new BoardState(4, 4);

            boardState.Grid.GetCell(0, 0).SetValue(2);
            boardState.Grid.GetCell(0, 1).SetValue(4);

            Debug.Log($"Cell (0,0): {boardState.Grid.GetCell(0, 0).Value}");
            Debug.Log($"Cell (0,1): {boardState.Grid.GetCell(0, 1).Value}");
        }
    }
}