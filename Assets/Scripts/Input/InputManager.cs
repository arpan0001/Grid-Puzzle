using System;
using UnityEngine;

using GridPuzzle.Utilities;

namespace GridPuzzle.Input
{
    public class InputManager : MonoBehaviour
    {
        public event Action<Direction> SwipePerformed;

        [SerializeField]
        private float minimumSwipeDistance = 50f;

        private Vector2 _startPosition;
        private bool _tracking;

        private void Update()
        {
#if UNITY_EDITOR || UNITY_STANDALONE

            HandleMouse();

#else

            HandleTouch();

#endif
        }

        private void HandleMouse()
        {
            if (UnityEngine.Input.GetMouseButtonDown(0))
            {
                _tracking = true;
                _startPosition = UnityEngine.Input.mousePosition;
            }

            if (_tracking &&
                UnityEngine.Input.GetMouseButtonUp(0))
            {
                DetectSwipe(
                    (Vector2)UnityEngine.Input.mousePosition);

                _tracking = false;
            }
        }

        private void HandleTouch()
        {
            if (UnityEngine.Input.touchCount == 0)
                return;

            Touch touch = UnityEngine.Input.GetTouch(0);

            switch (touch.phase)
            {
                case TouchPhase.Began:

                    _tracking = true;
                    _startPosition = touch.position;

                    break;

                case TouchPhase.Ended:

                    if (_tracking)
                    {
                        DetectSwipe(touch.position);
                    }

                    _tracking = false;

                    break;
            }
        }

        private void DetectSwipe(Vector2 endPosition)
        {
            Vector2 delta =
                endPosition - _startPosition;

            if (delta.magnitude < minimumSwipeDistance)
                return;

            Direction direction;

            if (Mathf.Abs(delta.x) >
                Mathf.Abs(delta.y))
            {
                direction =
                    delta.x > 0
                        ? Direction.Right
                        : Direction.Left;
            }
            else
            {
                direction =
                    delta.y > 0
                        ? Direction.Up
                        : Direction.Down;
            }

            SwipePerformed?.Invoke(direction);
        }
    }
}