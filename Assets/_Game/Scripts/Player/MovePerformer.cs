using UnityEngine;
using RH.Game.Settings;
using RH.Utilities.Extensions;
using RH.Game.Input;
using RH.Utilities.Attributes;

namespace RH.Game.Player
{
    public class MovePerformer : MonoBehaviour
    {
        private Rigidbody2D _rigidbody;
        private GroundDetectorByRay _groundDetector;

        private float _speed => GameSettings.Instance.MoveSpeed;

        [SerializeField, ReadOnly] private bool CanMove; //for inspector

        private void Start()
        {
            _rigidbody = GetComponent<Rigidbody2D>();
            _groundDetector = GetComponent<GroundDetectorByRay>();
        }

        private void Update() => TryMove();

        private void TryMove()
        {
            CanMove = _groundDetector.IsGrounded; //for inspector

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