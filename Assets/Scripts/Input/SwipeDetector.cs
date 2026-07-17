using System;
using UnityEngine;
using UnityEngine.InputSystem;
using GridPuzzle.Data;

namespace GridPuzzle.InputSystem
{
    /// <summary>
    /// Detects swipe gestures using Unity's New Input System.
    /// Supports both mouse and touchscreen.
    /// </summary>
    public class SwipeDetector : MonoBehaviour
    {
        public event Action<MoveDirection> OnSwipeDetected;

        [SerializeField]
        [Min(10f)]
        private float swipeThreshold = 80f;

        private Vector2 startPosition;
        private Vector2 endPosition;

        private void Update()
        {
            DetectMouseSwipe();
            DetectTouchSwipe();
        }

        #region Mouse

        private void DetectMouseSwipe()
        {
            if (Mouse.current == null)
                return;

            if (Mouse.current.leftButton.wasPressedThisFrame)
            {
                startPosition = Mouse.current.position.ReadValue();
            }

            if (Mouse.current.leftButton.wasReleasedThisFrame)
            {
                endPosition = Mouse.current.position.ReadValue();
                ProcessSwipe();
            }
        }

        #endregion

        #region Touch

        private void DetectTouchSwipe()
        {
            if (Touchscreen.current == null)
                return;

            var touch = Touchscreen.current.primaryTouch;

            if (touch.press.wasPressedThisFrame)
            {
                startPosition = touch.position.ReadValue();
            }

            if (touch.press.wasReleasedThisFrame)
            {
                endPosition = touch.position.ReadValue();
                ProcessSwipe();
            }
        }

        #endregion

        private void ProcessSwipe()
        {
            Vector2 delta = endPosition - startPosition;

            if (delta.magnitude < swipeThreshold)
                return;

            MoveDirection direction;

            if (Mathf.Abs(delta.x) > Mathf.Abs(delta.y))
            {
                direction = delta.x > 0
                    ? MoveDirection.Right
                    : MoveDirection.Left;
            }
            else
            {
                direction = delta.y > 0
                    ? MoveDirection.Up
                    : MoveDirection.Down;
            }

            OnSwipeDetected?.Invoke(direction);
        }
    }
}