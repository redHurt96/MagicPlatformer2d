using System;
using Between;
using UnityEngine;

namespace RH.Game.Input.Tracking
{
    public static class TouchInputService
    {
        public static event Action<Vector2> Pressed;
        public static event Action<Vector2> Dragged;
        public static event Action<Vector2> Released;

        public static void InvokePressedEvent(Vector2 where, ITouchInputHandler by) => Pressed?.Invoke(where);
        public static void InvokeDraggedEvent(Vector2 where, ITouchInputHandler by) => Dragged?.Invoke(where);
        public static void InvokeReleasedEvent(Vector2 where, ITouchInputHandler by) => Released?.Invoke(where);
    }
}