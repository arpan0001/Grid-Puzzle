using System;
using UnityEngine;
using GridPuzzle.Data;

namespace GridPuzzle.InputSystem
{
    /// <summary>
    /// Detects swipe gestures from both mouse and touch.
    /// </summary>
    public class SwipeDetector : MonoBehaviour
    {
        public event Action<MoveDirection> OnSwipeDetected;

        [SerializeField]
        private float swipeThreshold = 80f;

        private Vector2 startPosition;
        private Vector2 endPosition;

        private void Update()
        {
#if UNITY_EDITOR || UNITY_STANDALONE

            DetectMouseSwipe();

#else

            DetectTouchSwipe();

#endif
        }

        private void DetectMouseSwipe()
        {
            if (Input.GetMouseButtonDown(0))
            {
                startPosition = Input.mousePosition;
            }

            if (Input.GetMouseButtonUp(0))
            {
                endPosition = Input.mousePosition;

                ProcessSwipe();
            }
        }

        private void DetectTouchSwipe()
        {
            if (Input.touchCount == 0)
                return;

            Touch touch = Input.GetTouch(0);

            switch (touch.phase)
            {
                case TouchPhase.Began:

                    startPosition = touch.position;
                    break;

                case TouchPhase.Ended:

                    endPosition = touch.position;
                    ProcessSwipe();
                    break;
            }
        }

        private void ProcessSwipe()
        {
            Vector2 delta = endPosition - startPosition;

            if (delta.magnitude < swipeThreshold)
                return;

            if (Mathf.Abs(delta.x) > Mathf.Abs(delta.y))
            {
                if (delta.x > 0)
                    OnSwipeDetected?.Invoke(MoveDirection.Right);
                else
                    OnSwipeDetected?.Invoke(MoveDirection.Left);
            }
            else
            {
                if (delta.y > 0)
                    OnSwipeDetected?.Invoke(MoveDirection.Up);
                else
                    OnSwipeDetected?.Invoke(MoveDirection.Down);
            }
        }
    }
}