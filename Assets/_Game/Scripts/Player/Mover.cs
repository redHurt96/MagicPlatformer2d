using UnityEngine;
using RH.Game.Settings;
using RH.Game.Input;
using Sirenix.Utilities;

namespace RH.Game.Player
{
    public class Mover : MonoBehaviour
    {
        [SerializeField] private Rigidbody2D _rigidbody;
        [SerializeField] private SurfaceSlider _surfaceSlider;
        [SerializeField] private CollisionDetector _collisionDetector;
        
        private float _speed => PrototypeSettings.Instance.PlayerSpeed;
        private Vector2 _direction;

        private void Start()
        {
            KeyboardInput.OnInput += WriteDirection;
        }

        private void FixedUpdate()
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
            if (_direction == Vector2.zero || !_collisionDetector.IsGrounded)
                return;

            Vector2 directionAlongSurface = _surfaceSlider.Project(_direction.normalized);
            Vector2 offset = directionAlongSurface * (_speed * Time.deltaTime);

            _rigidbody.MovePosition(_rigidbody.position + offset);
        }
    }
}