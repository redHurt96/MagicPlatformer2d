using UnityEngine;
using UnityEngine.EventSystems;

namespace RH.Game.UI
{
    public abstract class BaseHoldButton : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
    {
        private bool _isHold = false;

        protected abstract void PerformOnHold();
        protected abstract void PerformOnRelease();

        public void OnPointerDown(PointerEventData eventData)
        {
            _isHold = true;
        }

        public void OnPointerUp(PointerEventData eventData)
        {
            _isHold = false;
            PerformOnRelease();
        }

        private void Update()
        {
            if (_isHold)
                PerformOnHold();
        }
    }
}