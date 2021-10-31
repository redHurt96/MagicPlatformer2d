using UnityEngine;
using RH.Game.Input;

namespace RH.Game.UI
{
    public class MoveButton : BaseHoldButton, IMovementInputServiceHandler
    {
        [SerializeField] private Direction _direction;

        private float _inputDirection => _direction == Direction.Left ? -1 : 1;

        protected override void PerformOnHold()
        {
            MovementInputService.SetDirection(_inputDirection, this);
        }

        protected override void PerformOnRelease()
        {
            MovementInputService.SetDirection(0f, this);
        }

        private enum Direction
        {
            Left = 0,
            Right
        }
    }
}