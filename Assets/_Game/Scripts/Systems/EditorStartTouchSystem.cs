using UnityEngine;
using UnityEngine.EventSystems;

namespace RH.Game.Systems
{
    public class EditorStartTouchSystem : BaseTouchSystem
    {
        protected override bool UnderUi => EventSystem.current.IsPointerOverGameObject();
        protected override bool HasTouch => Input.GetMouseButtonDown(0);
    }
}