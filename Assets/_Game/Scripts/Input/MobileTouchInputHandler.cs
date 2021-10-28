using UnityEngine;
using UnityEngine.EventSystems;

namespace RH.Game.Input.Tracking
{
    public class MobileTouchInputHandler : MonoBehaviour, IPointerDownHandler, IDragHandler, IPointerUpHandler,
        ITouchInputHandler
    {
        // private void Awake()
        // {
        //     if (Application.isEditor)
        //         Destroy(gameObject);
        // }

        public void OnPointerDown(PointerEventData eventData)
        {
            TouchInputService.InvokePressedEvent(this);
        }

        public void OnDrag(PointerEventData eventData)
        {
            TouchInputService.InvokeDraggedEvent(this);

        }

        public void OnPointerUp(PointerEventData eventData)
        {
            TouchInputService.InvokeReleasedEvent(this);
        }
    }
}