using RH.Game.Settings;
using UnityEngine;

namespace RH.Game.Input
{
    public class SimpleInputHandler : MonoBehaviour, IMovementInputServiceHandler
    {
        public const string HORIZONTAL = "Horizontal";
        public const string VERTICAL = "Vertical";

        private Vector2 Axis =>
            new Vector2(SimpleInput.GetAxis(HORIZONTAL), SimpleInput.GetAxis(VERTICAL));

        private float _jumpAngle => GameSettings.Instance.JoystickJumpAngle;
        private float _jumpAngleTan => Mathf.Tan(Mathf.Deg2Rad * _jumpAngle);


        private void Update()
        {
            MovementInputService.SetDirection(Axis.x, this);

            if (CanJump())
                MovementInputService.Jump(this);
        }

        private bool CanJump() => GetTangent(Axis) > _jumpAngleTan && Axis.y > 0 && Axis.magnitude > .5f;
        private float GetTangent(Vector2 offset) => offset.y / Mathf.Abs(offset.x);
    }
}