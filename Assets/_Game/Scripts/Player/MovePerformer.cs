using UnityEngine;
using RH.Game.Settings;
using RH.Game.Input;

namespace RH.Game.Player
{
    [RequireComponent(typeof(Rigidbody2D), typeof(CollisionDetector))]
    public class MovePerformer : MonoBehaviour
    {
        private Rigidbody2D _rigidbody;
        private CollisionDetector _collisionDetector;
        
        private float _speed => PrototypeSettings.Instance.MoveSpeed;
        private Vector2 _direction;

        private void Start()
        {
            _rigidbody = GetComponent<Rigidbody2D>();
            _collisionDetector = GetComponent<CollisionDetector>();

            KeyboardInput.OnInput += WriteDirection;
        }

        private void Update()
        {
            Move();
        }

        private void OnDestroy()
        {
            KeyboardInput.OnInput -= WriteDirection;
        }

        private void WriteDirection(Vector2 direction)
        {
            _direction = direction;
        }
        
        private void Move()
        {
            if (!_collisionDetector.IsGrounded)
                return;

            if (_direction == Vector2.zero)
            {
                _rigidbody.velocity = _direction;
            }
            else
            {
                Vector2 offset = _direction * _speed;
                _rigidbody.velocity = offset;
            }
        }
    }
}