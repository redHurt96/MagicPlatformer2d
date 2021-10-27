using RH.Game.Input;

namespace RH.Game.UI
{
    public class JumpButton : BaseButton, IInputServiceInvoker
    {
        protected override void PerformOnClick()
        {
            InputService.Jump(this);
        }
    }
}