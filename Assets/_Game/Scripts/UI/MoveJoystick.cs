using UnityEngine;

namespace RH.Game.UI
{
    public class MoveJoystick : BaseJoystick
    {
        protected override void PerformOnDrag(Vector2 toPosition)
        {
            SendMove(toPosition);
        }
    }
}