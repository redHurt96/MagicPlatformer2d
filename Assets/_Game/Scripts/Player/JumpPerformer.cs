using System.Collections;
using UnityEngine;
using RH.Game.Settings;
using RH.Game.Input;

namespace RH.Game.Player
{
    [RequireComponent(typeof(Rigidbody2D), typeof(CollisionDetector))]
    public class JumpPerformer : MonoBehaviour
    {
        private Rigidbody2D _rigidbody;
        private CollisionDetector _collisionDetector;

        public bool IsJumping { get; private set; }

        private PrototypeSettings _settings => PrototypeSettings.Instance;
        private AnimationCurve _curve => _settings.JumpCurve;
        private float _height => _settings.JumpHeight;
        private float _speed => _settings.MoveSpeed;
        private float _airControlPercent => _settings.AirControlPercent;
        private float _time => _settings.JumpTime;
        private bool _isGrounded => _collisionDetector.IsCollide;
        private float _moveDirection => InputService.MoveDirection.x;

        private void Start()
        {
            _rigidbody = GetComponent<Rigidbody2D>();
            _collisionDetector = GetComponent<CollisionDetector>();

            InputService.OnJump += TryJump;
        }

        private void OnDestroy()
        {
            InputService.OnJump -= TryJump;
        }

        private void TryJump()
        {
            if (_isGrounded)
                StartCoroutine(PerformJump());
        }

        private IEnumerator PerformJump()
        {
            _rigidbody.velocity = Vector2.zero;
            IsJumping = true;

            float jumpTime = 0f;
            Vector2 startPoint = transform.position;
            bool hasStartCollisions = true;
            float startDirection = _moveDirection;

            while (inAir(hasStartCollisions))
            {
                Vector2 position = CalculatePosition(jumpTime, startPoint, startDirection);

                _rigidbody.MovePosition(position);
                
                if (!_collisionDetector.IsCollide && hasStartCollisions)
                    hasStartCollisions = false;

                jumpTime += Time.fixedDeltaTime;

                yield return new WaitForFixedUpdate();
            }

            IsJumping = false;

            yield break;

        }

        private Vector2 CalculatePosition(float jumpTime, Vector2 startPoint, float startDirection)
        {
            return new Vector2(transform.position.x + CalculateHorizontalOffset(startDirection), CalculateVerticalOffset(jumpTime, startPoint.y));
        }

        private float CalculateHorizontalOffset(float startDirection)
        {
            var inputCoefficient = Mathf.Lerp(startDirection, _moveDirection, _airControlPercent);
            return _speed * Time.fixedDeltaTime * inputCoefficient;
        }

        private float CalculateVerticalOffset(float jumpTime, float startPointY)
        {
            var curvePoint = _curve.Evaluate(jumpTime / _time);
            var height = curvePoint * _height;
            return startPointY + height;
        }

        private bool inAir(bool hasStartCollisions) => !_isGrounded || (_isGrounded && hasStartCollisions);
    }
}
