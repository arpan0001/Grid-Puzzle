using UnityEngine;
using GridPuzzle.Data;
using GridPuzzle.InputSystem;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private InputManager inputManager;

    private void OnEnable()
    {
        inputManager.OnMoveRequested += MoveRequested;
    }

    private void OnDisable()
    {
        inputManager.OnMoveRequested -= MoveRequested;
    }

    private void MoveRequested(MoveDirection direction)
    {
        Debug.Log($"GameManager received {direction}");
    }
}