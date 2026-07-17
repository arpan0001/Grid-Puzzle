using UnityEngine;
using GridPuzzle.Data;

namespace GridPuzzle.InputSystem
{
    /// <summary>
    /// Receives swipe events and forwards them
    /// to the gameplay systems.
    /// </summary>
    public class InputManager : MonoBehaviour
    {
        [SerializeField]
        private SwipeDetector swipeDetector;

        public event System.Action<MoveDirection> OnMoveRequested;

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

            OnMoveRequested?.Invoke(direction);
        }
    }
}