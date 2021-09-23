using System.Collections;
using UnityEngine;
using RH.Game.Settings;
using RH.Game.Input;

namespace RH.Game.Player
{
    public class Jumper : MonoBehaviour
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
            if (KeyboardInput.JumpButtonPressed && _isGrounded)
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
            bool hasStartCollisions = true;
            float startDirection = KeyboardInput.Direction;
            Vector2 startPoint = transform.position;

            while (inAir())
            {
                transform.position = new Vector2(CalculateHorizontalPosition(), CalculateVerticalPosition());
                jumpTime += Time.deltaTime;

                UpdateCollisionsTrigger();
                
                yield return null;
            }

            IsJumping = false;
            yield break;

            float CalculateHorizontalPosition()
            {
                var inputCoefficient = Mathf.Lerp(startDirection, KeyboardInput.Direction, _airControlPercent);
                return transform.position.x + _lenght * Time.deltaTime * inputCoefficient;
            }
            
            float CalculateVerticalPosition()
            {                
                var curvePoint = _curve.Evaluate(jumpTime / _time);
                var height = curvePoint * _height;
                return startPoint.y + height;
            }
    
            bool inAir() => !_isGrounded || (_isGrounded && hasStartCollisions);

            void UpdateCollisionsTrigger()
            {
                if (!_collisionDetector.IsCollide && hasStartCollisions)
                    hasStartCollisions = false;
            }
        }
    }
}
