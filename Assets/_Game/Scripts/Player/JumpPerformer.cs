using System.Collections;
using UnityEngine;
using RH.Game.Settings;
using RH.Game.Input;
using TMPro;

namespace RH.Game.Player
{
    [RequireComponent(typeof(Rigidbody2D), typeof(CollisionDetector))]
    public class JumpPerformer : MonoBehaviour
    {
        private Rigidbody2D _rigidbody;
        private CollisionDetector _collisionDetector;

        public bool IsJumping { get; private set; }

        private Vector2 _jumpStartPoint;
        private float _jumpTime = 0f;
        private bool _hasStartCollisions;
        private float _startDirection;

        private GameSettings _settings => GameSettings.Instance;
        private AnimationCurve _curve => _settings.JumpCurve;
        private float _height => _settings.JumpHeight;
        private float _speed => _settings.MoveSpeed;
        private float _airControlPercent => _settings.AirControlPercent;
        private float _time => _settings.JumpTime;
        private bool _isGrounded => _collisionDetector.IsCollide;
        private float _moveDirection => InputService.MoveDirection.x;
        private float _curveLenghtTime => _curve.keys[^1].time;

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
            SetStartValues();

            while (InAir(_hasStartCollisions))
            {
                float previousHeight = _rigidbody.position.y;

                Move(_jumpStartPoint, _startDirection);
                UpdateStartCollisionsFlag();
                IncreaseJumpTime();

                yield return new WaitForFixedUpdate();

                if (JumpCompleted(_jumpTime))
                {
                    ApplyFallVelocity(previousHeight);
                    break;
                }
            }

            IsJumping = false;

            yield break;
        }

        private void SetStartValues()
        {
            IsJumping = true;
            _jumpStartPoint = _rigidbody.position;
            _hasStartCollisions = true;
            _startDirection = _moveDirection;
            _jumpTime = 0f;
        }

        private void IncreaseJumpTime()
        {
            _jumpTime += Time.fixedDeltaTime;
        }

        private void UpdateStartCollisionsFlag()
        {
            if (!_collisionDetector.IsCollide && _hasStartCollisions)
                _hasStartCollisions = false;
        }

        private bool InAir(bool hasStartCollisions) => !_isGrounded || (_isGrounded && hasStartCollisions);

        private bool JumpCompleted(float jumpTime) => jumpTime >= _curveLenghtTime;

        private void Move(Vector2 startPoint, float startDirection)
        {
            Vector2 position = CalculatePosition(startPoint, startDirection);
            _rigidbody.MovePosition(position);
        }

        private Vector2 CalculatePosition(Vector2 startPoint, float startDirection)
        {
            return new Vector2(transform.position.x + CalculateHorizontalOffset(startDirection), CalculateVerticalOffset(startPoint.y));
        }

        private float CalculateHorizontalOffset(float startDirection)
        {
            var inputCoefficient = Mathf.Lerp(startDirection, _moveDirection, _airControlPercent);
            return _speed * Time.fixedDeltaTime * inputCoefficient;
        }

        private float CalculateVerticalOffset(float startPointY)
        {
            var curvePoint = _curve.Evaluate(_jumpTime);
            var height = curvePoint * _height;
            return startPointY + height;
        }

        private void ApplyFallVelocity(float previousHeight)
        {
            _rigidbody.velocity = new Vector2(_rigidbody.velocity.x, (_rigidbody.position.y - previousHeight) / Time.fixedDeltaTime);
        }
    }
}
