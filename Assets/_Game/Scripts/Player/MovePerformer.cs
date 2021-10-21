using UnityEngine;
using RH.Game.Settings;
using RH.Utilities.Extensions;
using RH.Game.Input;

namespace RH.Game.Player
{
    [RequireComponent(typeof(Rigidbody2D), typeof(CollisionDetector))]
    public class MovePerformer : MonoBehaviour
    {
        private Rigidbody2D _rigidbody;
        private CollisionDetector _collisionDetector;

        private float _speed => PrototypeSettings.Instance.MoveSpeed;

        private void Start()
        {
            _rigidbody = GetComponent<Rigidbody2D>();
            _collisionDetector = GetComponent<CollisionDetector>();
        }

        private void Update()
        {
            Move();
        }

        private void Move()
        {
            if (!_collisionDetector.IsGrounded)
                return;

            var direction = MoveInput.Direction;

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
            Vector2 offset = direction * _speed;
            _rigidbody.velocity = offset;
        }
    }
}