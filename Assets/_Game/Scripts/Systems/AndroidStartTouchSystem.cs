using UnityEngine;
using UnityEngine.EventSystems;

namespace RH.Game.Systems
{
    public class AndroidStartTouchSystem : BaseTouchSystem
    {
        protected override bool UnderUi => EventSystem.current.IsPointerOverGameObject(Input.GetTouch(0).fingerId);
        protected override bool HasTouch => Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began;
    }
}