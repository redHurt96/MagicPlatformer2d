using System;
using UnityEngine;
using UnityEngine.EventSystems;
using Between;

namespace RH.Game.Input.Tracking
{
    public class TouchInput : MonoBehaviour
    {
        public static event Action Pressed;
        public static event Action Dragged;
        public static event Action Released;

        public static Vector2 ScreenPosition => _mousePosition;
        public static Vector3 WorldPosition => GameCamera.ScreenToWorldPoint(ScreenPosition);
        private static Vector2 _mousePosition => UnityEngine.Input.mousePosition;

        private InputState _state = InputState.None;
        private Vector2 _pressPosition;
        private Vector2 _previousPosition;

        private bool _underUi => UnderUiTouchDetector.IsUnderUi;

        private void Update()
        {
            if (UnityEngine.Input.GetMouseButtonDown(0) && _state == InputState.None && !_underUi)
                PerformPress();
            else if (IsStartDrag())
                PerformStartDrag();
            else if (IsDrag())
                PerformDrag();
            else if (_state != InputState.None && !UnityEngine.Input.GetMouseButton(0))
                PerformRelease();

            bool IsStartDrag() => UnityEngine.Input.GetMouseButton(0) && _state == InputState.Press && _mousePosition != _pressPosition;
            bool IsDrag() => UnityEngine.Input.GetMouseButton(0) && _state == InputState.Drag && _mousePosition != _previousPosition;
        }

        private void PerformPress()
        {
            _pressPosition = _mousePosition;
            _state = InputState.Press;
            
            Pressed?.Invoke();
        }

        private void PerformStartDrag()
        {
            _previousPosition = _mousePosition;
            _state = InputState.Drag;
            Dragged?.Invoke();
        }

        private void PerformDrag()
        {
            _previousPosition = _mousePosition;
            Dragged?.Invoke();
        }

        private void PerformRelease()
        {
            _state = InputState.None;
            Released?.Invoke();
        }

        private enum InputState
        {
            None = 0,
            Press,
            Drag
        }
    }
}
