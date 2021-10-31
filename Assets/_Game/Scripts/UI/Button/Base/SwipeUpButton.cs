using UnityEngine;
using UnityEngine.EventSystems;

namespace RH.Game.UI
{
    public abstract class SwipeUpButton : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
    {
        private Vector2 _enterPosition;

        public void OnPointerEnter(PointerEventData eventData)
        {
            _enterPosition = eventData.position;
        }

        public void OnPointerExit(PointerEventData eventData)
        {
            if (eventData.position.y > _enterPosition.y)
                PerformOnSwipe();
        }

        protected abstract void PerformOnSwipe();
    }
}