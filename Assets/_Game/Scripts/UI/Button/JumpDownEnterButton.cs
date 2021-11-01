using RH.Game.Input;

namespace RH.Game.UI
{
    public class JumpDownEnterButton : DownEnterButton, IMovementInputServiceHandler
    {
        protected override void PerformOnEnter()
        {
            MovementInputService.Jump(this);
        }
    }
}