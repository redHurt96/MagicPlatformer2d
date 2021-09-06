using UnityEngine;
using RH.Game.UserInput;

namespace RH.Game.Player
{
    public class PhycicsMovement : MonoBehaviour
    {
        [SerializeField] private Rigidbody2D _rigidbody;
        [SerializeField] private SurfaceSlider _surfaceSlider;
        [SerializeField] private float _speed;

        [Header("ReadOnly")]
        [SerializeField] private Vector2 _offset;
        [SerializeField] private float _roSpeed;
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
            if (_direction == Vector2.zero)
                return;

            Vector2 directionAlongSurface = _surfaceSlider.Project(_direction.normalized);
            Vector2 offset = directionAlongSurface * (_speed * Time.deltaTime);
            
            _offset = offset;
            _roSpeed = offset.magnitude / Time.deltaTime;
            
            _rigidbody.MovePosition(_rigidbody.position + offset);
        }
    }
}