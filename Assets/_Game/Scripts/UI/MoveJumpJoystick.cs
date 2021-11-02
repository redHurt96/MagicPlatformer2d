using UnityEngine;
using RH.Game.Input;
using System.IO;

namespace RH.Game.UI
{
    public class MoveJumpJoystick : BaseJoystick
    {
        [SerializeField] private float _verticalJumpAngle;
        [SerializeField] private float _jumpAngle;
        [SerializeField] private float _jumpRadius;

        private float _jumpAngleTan => Mathf.Tan(Mathf.Deg2Rad * _jumpAngle);

        protected override void PerformOnDrag(Vector2 toPosition)
        {
            SendMove(toPosition);
            TryJump(toPosition);
        }

        private void TryJump(Vector2 toPosition)
        {
            var offset = (toPosition - _beginPosition);

            if (LessThenJumpRadius(offset))
                return;

            offset.Normalize();

            if (CanJump(offset))
            {
                SetJumpDirection(offset);
                MovementInputService.Jump(this);
            }
        }

        private void SetJumpDirection(Vector2 offset)
        {
            if (AngleEnoughToVerticalJump(offset))
                MovementInputService.SetDirection(0f, this);
            else
                MovementInputService.SetDirection(Mathf.Sign(offset.x), this);
        }

        private bool LessThenJumpRadius(Vector2 offset) => offset.sqrMagnitude < Mathf.Pow(_jumpRadius, 2);
        private bool CanJump(Vector2 offset) => GetTangent(offset) > _jumpAngleTan && offset.y > 0;
        private float GetTangent(Vector2 offset) => offset.y / Mathf.Abs(offset.x);
        private bool AngleEnoughToVerticalJump(Vector2 offset)
        {
            var atan = Mathf.Atan2(offset.y, offset.x);
            var atanInDegrees = Mathf.Rad2Deg * atan;
            var angle = 90 - atanInDegrees;
            return Mathf.Abs(angle) < _verticalJumpAngle;
        }
    }
}