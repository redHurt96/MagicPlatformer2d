using RH.Game.Input;
using RH.Game.Settings;
using UnityEngine;

namespace RH.Game.Player
{
    [RequireComponent(typeof(CollisionDetector), typeof(JumpPerformer), typeof(Rigidbody2D))]
    public class FallPerformer : MonoBehaviour
    {
        private CollisionDetector _collisionDetector;
        private JumpPerformer _jumpPerformer;
        private Rigidbody2D _rigidbody;

        private float _speed => GameSettings.Instance.MoveSpeed;
        private float _fallAirControl => GameSettings.Instance.FallAirControlPercent;
        private float _moveDirection => InputService.MoveDirection.x;

        private void Start()
        {
            _collisionDetector = GetComponent<CollisionDetector>();
            _jumpPerformer = GetComponent<JumpPerformer>();
            _rigidbody = GetComponent<Rigidbody2D>();
        }

        private void Update()
        {
            if (!_collisionDetector.IsCollide && !_jumpPerformer.IsJumping)
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