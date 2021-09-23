using RH.Game.Input;
using RH.Utilities.StateMachine2;

namespace RH.Game.Player.Movement.Desicions
{
    public class MoveDecision : Decision
    {
        public override bool CanTranslate => KeyboardInput.IsMoving;

        public MoveDecision(IState targetState) : base(targetState) {}
    }
}