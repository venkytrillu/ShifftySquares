using UnityEngine;

public interface IInputService
{
    Vector2 LeftStick { get; }
    Vector2 RightStick { get; }
    bool Action1WasPressed { get; }
    bool Action1IsPressed { get; }
    bool Action1WasReleased { get; }
    float Action1PressedTime { get; }
}