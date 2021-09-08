using System.Collections;
using UnityEngine;
using RH.Game.Settings;
using RH.Game.UserInput;

namespace RH.Game.Player
{
    public class CurveJumper : MonoBehaviour
    {
        [SerializeField] private CollisionDetector _collisionDetector;
        
        public bool IsJumping { get; private set; }

        private PrototypeSettings _settings => PrototypeSettings.Instance;
        private AnimationCurve _curve => _settings.JumpCurve;
        private float _height => _settings.JumpHeight;
        private float _lenght => _settings.JumpLenght;
        private float _airControlPercent => _settings.AirControlPercent;
        private float _time => _settings.JumpTime;
        private bool _isGrounded => _collisionDetector.IsCollide;

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space) && _isGrounded)
                Jump();
        }

        private void Jump()
        {
            StartCoroutine(PerformJump());
        }

        private IEnumerator PerformJump()
        {
            IsJumping = true;
            float jumpTime = 0f;
            Vector2 startPoint = transform.position;
            bool hasStartCollisions = true;
            float startDirection = KeyboardInput.Direction;

            while (inAir())
            {
                transform.position = new Vector2(transform.position.x + CalculateHorizontalOffset(), CalculateVerticalOffset());
                jumpTime += Time.deltaTime;
             
                if (!_collisionDetector.IsCollide && hasStartCollisions)
                    hasStartCollisions = false;
                
                yield return null;
            }
            
            IsJumping = false;
            yield break;

            float CalculateHorizontalOffset()
            {
                var inputCoefficient = Mathf.Lerp(startDirection, KeyboardInput.Direction, _airControlPercent);
                return _lenght * Time.deltaTime * inputCoefficient;
            }
            float CalculateVerticalOffset()
            {                
                var curvePoint = _curve.Evaluate(jumpTime / _time);
                var height = curvePoint * _height;
                return startPoint.y + height;
            }
            bool inAir() => !_isGrounded || (_isGrounded && hasStartCollisions);
        }
    }
}
