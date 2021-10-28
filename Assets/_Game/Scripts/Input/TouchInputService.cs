using System;
using Between;
using UnityEngine;

namespace RH.Game.Input.Tracking
{
    public static class TouchInputService
    {
        public static event Action Pressed;
        public static event Action Dragged;
        public static event Action Released;

        public static Vector2 ScreenPosition => UnityEngine.Input.mousePosition;
        public static Vector3 WorldPosition => GameCamera.ScreenToWorldPoint(ScreenPosition);

        public static void InvokePressedEvent(ITouchInputInvoker by) => Pressed?.Invoke();
        
        public static void InvokeDraggedEvent(ITouchInputInvoker by) => Dragged?.Invoke();
        
        public static void InvokeReleasedEvent(ITouchInputInvoker by) => Released?.Invoke();
    }
}