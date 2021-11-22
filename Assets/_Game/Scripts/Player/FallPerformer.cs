using RH.Game.Input;
using RH.Game.Settings;
using RH.Utilities.Attributes;
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

        [SerializeField, ReadOnly] private bool _isFall; //for inspector

        private void Start()
        {
            _groundDetector = GetComponent<GroundDetectorByRay>();
            _jumpPerformer = GetComponent<JumpPerformer>();
            _rigidbody = GetComponent<Rigidbody2D>();
        }

        private void Update()
        {
            if (!_groundDetector.IsGrounded && !_jumpPerformer.IsJumping)
                Fall();

            ShowInInspector();
        }

        private void Fall()
        {
            float velocityX = CalculateVelocity();
            _rigidbody.velocity = new Vector2(velocityX, _rigidbody.velocity.y);
        }

        private float CalculateVelocity() => 
            Mathf.Lerp(_rigidbody.velocity.x, _moveDirection * _speed, _fallAirControl);

        private void ShowInInspector() => 
            _isFall = !(_groundDetector.IsGrounded || _jumpPerformer.IsJumping);
    }
}