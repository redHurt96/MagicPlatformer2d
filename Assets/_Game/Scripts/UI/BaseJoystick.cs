using System;
using UnityEngine;
using UnityEngine.EventSystems;
using RH.Game.Input;

namespace RH.Game.UI
{
    public abstract class BaseJoystick : MonoBehaviour, IPointerDownHandler, IDragHandler, IPointerUpHandler, IMovementInputServiceHandler
    {
        public event Action<Vector2> Setted;
        public event Action<Vector2> Moved;
        public event Action<Vector2> Removed;

        protected Vector2 _beginPosition { get; private set; }

        [SerializeField] private float _dragTheshhold;

        public void OnPointerDown(PointerEventData eventData)
        {
            _beginPosition = eventData.position;
            Setted?.Invoke(eventData.position);
        }

        public void OnDrag(PointerEventData eventData)
        {
            PerformOnDrag(eventData.position);
            Moved?.Invoke(eventData.position);
        }

        public void OnPointerUp(PointerEventData eventData)
        {
            Stop();
            Removed?.Invoke(eventData.position);
        }

        protected abstract void PerformOnDrag(Vector2 toPosition);
        protected virtual void PerformOnStop() { }

        protected bool TryMove(Vector2 toPosition)
        {
            var offset = toPosition - _beginPosition;

            if (LessThenDragRadius(offset))
            {
                Stop();
                return false;
            }
            else
            {
                MovementInputService.SetDirection(offset.normalized.x, this);
                return true;
            }
        }

        private bool LessThenDragRadius(Vector2 offset)
            => offset.sqrMagnitude < Mathf.Pow(_dragTheshhold, 2);

        private void Stop()
        {
            MovementInputService.SetDirection(0f, this);
            PerformOnStop();
        }
    }
}