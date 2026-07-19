using System;
using UnityEngine;
using GridPuzzle.Utilities;

namespace GridPuzzle.Input
{
    // Detects player swipe input.
    // Supports both Mouse (Editor/PC)
    // and Touch (Mobile).
    // Sends the swipe direction to other systems.
   
    public class InputManager : MonoBehaviour
    {
        public event Action<Direction> SwipePerformed;

        [SerializeField]
        [Tooltip("Minimum distance required to recognize a swipe.")]
        private float minimumSwipeDistance = 50f;

        private Vector2 _startPosition;
        private bool _tracking;

        /// Called every frame.Uses Mouse input in the Editor and Touch input on Mobile devices.

        private void Update()
        {
            HandleMouse();
            HandleTouch();
        }

        // Handles swipe detection using the mouse.
        // Used while testing in the Unity Editor.  
        private void HandleMouse()
        {
            
            if (UnityEngine.Input.GetMouseButtonDown(0))
            {
                _tracking = true;
                _startPosition = UnityEngine.Input.mousePosition;
            }

            // Player released the mouse button.
            if (_tracking &&
                UnityEngine.Input.GetMouseButtonUp(0))
            {
                DetectSwipe((Vector2)UnityEngine.Input.mousePosition);

                _tracking = false;
            }
        }

        /// Handles swipe detection using touch input.
        /// Used on Android and iOS devices.
        private void HandleTouch()
        {
           
            if (UnityEngine.Input.touchCount == 0)
                return;

            Touch touch = UnityEngine.Input.GetTouch(0);

            switch (touch.phase)
            {
                // Finger touched the screen.
                case TouchPhase.Began:

                    _tracking = true;
                    _startPosition = touch.position;

                    break;

                // Finger lifted from the screen.
                case TouchPhase.Ended:

                    if (_tracking)
                    {
                        DetectSwipe(touch.position);
                    }

                    _tracking = false;

                    break;
            }
        }

        // Calculates the swipe direction. If the swipe is long enough,it notifies the game using the SwipePerformed event.
        
        private void DetectSwipe(Vector2 endPosition)
        {
            
            Vector2 delta = endPosition - _startPosition;

            
            if (delta.magnitude < minimumSwipeDistance)
                return;

            Direction direction;

            
            if (Mathf.Abs(delta.x) > Mathf.Abs(delta.y))
            {
                direction =delta.x > 0? Direction.Right: Direction.Left;
            }
            else
            {
              direction = delta.y > 0 ? Direction.Up : Direction.Down;
            }

            SwipePerformed?.Invoke(direction);
        }
    }
}