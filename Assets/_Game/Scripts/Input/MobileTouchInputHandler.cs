using Between;
using UnityEngine;
using UnityEngine.EventSystems;

namespace RH.Game.Input.Tracking
{
    public class MobileTouchInputHandler : MonoBehaviour, IPointerDownHandler, IDragHandler, IPointerUpHandler,
        ITouchInputHandler
    {

        public void OnPointerDown(PointerEventData eventData)
        {
            TouchInputService.InvokePressedEvent(GameCamera.ScreenToWorldPoint(eventData.position), this);
        }

        public void OnDrag(PointerEventData eventData)
        {
            TouchInputService.InvokeDraggedEvent(GameCamera.ScreenToWorldPoint(eventData.position), this);
        }

        public void OnPointerUp(PointerEventData eventData)
        {
            TouchInputService.InvokeReleasedEvent(GameCamera.ScreenToWorldPoint(eventData.position), this);
        }
    }
}