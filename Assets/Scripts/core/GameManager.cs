using UnityEngine;
using GridPuzzle.Core;
using GridPuzzle.Data;

public class GameManager : MonoBehaviour
{
    private void OnEnable()
    {
        GameEvents.MoveRequested += HandleMoveRequested;
    }

    private void OnDisable()
    {
        GameEvents.MoveRequested -= HandleMoveRequested;
    }

    private void HandleMoveRequested(MoveDirection direction)
    {
        Debug.Log($"Received {direction}");

        // MoveProcessor.Execute(direction);
    }
}