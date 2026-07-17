using UnityEngine;
using GridPuzzle.Core;
using GridPuzzle.Data;
using GridPuzzle.InputSystem;

namespace GridPuzzle.Input
{
    public class InputManager : MonoBehaviour
    {
        [SerializeField]
        private SwipeDetector swipeDetector;

        private void OnEnable()
        {
            swipeDetector.OnSwipeDetected += HandleSwipe;
        }

        private void OnDisable()
        {
            swipeDetector.OnSwipeDetected -= HandleSwipe;
        }

        private void HandleSwipe(MoveDirection direction)
        {
            Debug.Log($"Move Requested : {direction}");

            GameEvents.RaiseMoveRequested(direction);
        }
    }
}