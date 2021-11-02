using System;
using UnityEngine;
using UnityEngine.EventSystems;
using RH.Game.Input;

namespace RH.Game.UI
{
    public class Joystick : MonoBehaviour, IPointerDownHandler, IDragHandler, IPointerUpHandler, IMovementInputServiceHandler
    {
        public event Action<Vector2> Setted;
        public event Action<Vector2> Moved;
        public event Action<Vector2> Removed;

        private Vector2 _beginPosition;

        public void OnPointerDown(PointerEventData eventData)
        {
            _beginPosition = eventData.position;
            Setted?.Invoke(eventData.position);
        }

        public void OnDrag(PointerEventData eventData)
        {
            float direction = eventData.position.x > _beginPosition.x ? 1f : -1f;
            MovementInputService.SetDirection(direction, this);
            Moved?.Invoke(eventData.position);
        }

        public void OnPointerUp(PointerEventData eventData)
        {
            Stop();
            Removed?.Invoke(eventData.position);
        }

        private void Stop()
        {
            MovementInputService.SetDirection(0f, this);
        }
    }
}