using RH.Game.Input;
using RH.Utilities.StateMachine2;

namespace RH.Game.Player.Movement.Desicions
{
    public class JumpDecision : Decision
    {
        public override bool CanTranslate => KeyboardInput.JumpButtonPressed;

        public JumpDecision(IState targetState) : base(targetState) {}
    }
}