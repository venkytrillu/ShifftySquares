using UnityEngine;


    public class UnityInputService : UnityDebugLogService, IInputService
    {
        public Vector2 LeftStick
        {
            get { return new Vector2(Input.GetAxis("horizontal"), Input.GetAxis("Vertical")); }
        }

        public Vector2 RightStick { get; }
        public bool Action1WasPressed { get; }
        private bool action1IsPressed;

        public bool Action1IsPressed
        {
            get
            {
                action1IsPressed = Input.GetMouseButtonDown(0);
                return action1IsPressed;
            }
        }

        public bool Action1WasReleased { get; }
        public float Action1PressedTime { get; }
    }
