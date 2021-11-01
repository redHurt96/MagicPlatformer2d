using UnityEngine;
using UnityEngine.EventSystems;
using RH.Game.Input;

namespace RH.Game.UI
{
    public class JoystickArea : MonoBehaviour, IPointerDownHandler, IDragHandler, IPointerUpHandler, IMovementInputServiceHandler
    {
        private Vector2 _beginPosition;

        public void OnPointerDown(PointerEventData eventData)
        {
            _beginPosition = eventData.position;
        }

        public void OnDrag(PointerEventData eventData)
        {
            float direction = eventData.position.x > _beginPosition.x ? 1f : -1f;
            MovementInputService.SetDirection(direction, this);
        }

        public void OnDrop(PointerEventData eventData) => Stop();

        public void OnPointerUp(PointerEventData eventData) => Stop();

        private void Stop()
        {
            MovementInputService.SetDirection(0f, this);
        }
    }
}