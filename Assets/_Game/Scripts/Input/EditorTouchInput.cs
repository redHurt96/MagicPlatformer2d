using System;
using UnityEngine;
using Between;

namespace RH.Game.Input.Tracking
{
    public class EditorTouchInput : MonoBehaviour, ITouchInputInvoker
    {
        private static Vector2 _mousePosition => UnityEngine.Input.mousePosition;

        private InputState _state = InputState.None;
        private Vector2 _pressPosition;
        private Vector2 _previousPosition;

        private bool _underUi => UnderUiTouchDetector.IsUnderUi;
        private bool _isStartPress => UnityEngine.Input.GetMouseButtonDown(0) && _state == InputState.None && !_underUi;
        private bool _isStartDrag => UnityEngine.Input.GetMouseButton(0) && _state == InputState.Press && _mousePosition != _pressPosition;
        private bool _isDrag => UnityEngine.Input.GetMouseButton(0) && _state == InputState.Drag && _mousePosition != _previousPosition;
        private bool _isRelease => _state != InputState.None && !UnityEngine.Input.GetMouseButton(0);

        private void Awake()
        {
            if (!Application.isEditor)
                Destroy(gameObject);
        }

        private void Update()
        {
            if (_isStartPress)
                PerformPress();
            else if (_isStartDrag)
                PerformStartDrag();
            else if (_isDrag)
                PerformDrag();
            else if (_isRelease)
                PerformRelease();
        }

        private void PerformPress()
        {
            _pressPosition = _mousePosition;
            _state = InputState.Press;
            
            TouchInputService.InvokePressedEvent(this);
        }

        private void PerformStartDrag()
        {
            _previousPosition = _mousePosition;
            _state = InputState.Drag;
            
            TouchInputService.InvokeDraggedEvent(this);
        }

        private void PerformDrag()
        {
            _previousPosition = _mousePosition;
            
            TouchInputService.InvokeDraggedEvent(this);
        }

        private void PerformRelease()
        {
            _state = InputState.None;
            TouchInputService.InvokeReleasedEvent(this);
        }

        private enum InputState
        {
            None = 0,
            Press,
            Drag
        }
    }
}
