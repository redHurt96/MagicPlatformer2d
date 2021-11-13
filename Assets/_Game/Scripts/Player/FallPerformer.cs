using RH.Game.Input;
using RH.Game.Settings;
using UnityEngine;

namespace RH.Game.Player
{
    public class FallPerformer : MonoBehaviour
    {
        private GroundDetectorByRay _groundDetector;
        private JumpPerformer _jumpPerformer;
        private Rigidbody2D _rigidbody;

        private float _speed => GameSettings.Instance.MoveSpeed;
        private float _fallAirControl => GameSettings.Instance.FallAirControlPercent;
        private float _moveDirection => MovementInputService.MoveDirection.x;

        public bool IsFall; //for inspector

        private void Start()
        {
            _groundDetector = GetComponent<GroundDetectorByRay>();
            _jumpPerformer = GetComponent<JumpPerformer>();
            _rigidbody = GetComponent<Rigidbody2D>();
        }

        private void Update()
        {
            IsFall = !_groundDetector.IsGrounded && !_jumpPerformer.IsJumping; //for inspector

            if (!_groundDetector.IsGrounded && !_jumpPerformer.IsJumping)
                Move();
        }

        private void Move()
        {
            float velocityX = CalculateVelocity();
            _rigidbody.velocity = new Vector2(velocityX, _rigidbody.velocity.y);
        }

        private float CalculateVelocity()
        {
            return Mathf.Lerp(_rigidbody.velocity.x, _moveDirection * _speed, _fallAirControl);
        }
    }
}