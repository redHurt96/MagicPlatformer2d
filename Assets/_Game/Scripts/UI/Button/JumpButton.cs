using RH.Game.Input;

namespace RH.Game.UI
{
    public class JumpButton : BaseButton, IMovementInputServiceHandler
    {
        protected override void PerformOnClick()
        {
            MovementInputService.Jump(this);
        }
    }
}