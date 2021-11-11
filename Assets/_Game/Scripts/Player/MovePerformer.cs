using UnityEngine;
using RH.Game.Settings;
using RH.Utilities.Extensions;
using RH.Game.Input;

namespace RH.Game.Player
{
    [RequireComponent(typeof(Rigidbody2D), typeof(GroundDetector))]
    public class MovePerformer : MonoBehaviour
    {
        private Rigidbody2D _rigidbody;
        private GroundDetector _groundDetector;

        private float _speed => GameSettings.Instance.MoveSpeed;

        private void Start()
        {
            _rigidbody = GetComponent<Rigidbody2D>();
            _groundDetector = GetComponent<GroundDetector>();
        }

        private void Update() => TryMove();

        private void TryMove()
        {
            if (!_groundDetector.IsGrounded)
                return;

            Move();
        }

        private void Move()
        {
            var direction = MovementInputService.MoveDirection;

            if (direction.Approximately(Vector2.zero))
                ClearVelocity();
            else
                SetVelocity(direction);
        }

        private void ClearVelocity()
        {
            _rigidbody.velocity = Vector2.zero;
        }
        
        private void SetVelocity(Vector2 direction)
        {
            _rigidbody.velocity = direction * _speed;
        }
    }
}