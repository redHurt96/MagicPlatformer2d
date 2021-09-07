using System.Collections;
using RH.Game.UserInput;
using UnityEngine;

namespace RH.Game.Player
{
    public class CurveJumper : MonoBehaviour
    {
        [SerializeField] private CollisionDetector _collisionDetector;
        [SerializeField] private AnimationCurve _curve;
        [SerializeField] private float _height;
        [SerializeField] private float _lenght;
        [SerializeField] private float _time;

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
            float jumpTime = 0f;
            Vector2 startPoint = transform.position;
            bool hasStartCollisions = true;

            while (inAir())
            {
                var progress = jumpTime / _time;
                var curvePoint = _curve.Evaluate(progress);

                var height = curvePoint * _height;
                var lenghtOffset = _lenght * KeyboardInput.Direction * Time.deltaTime;
                var newPosition = new Vector2(transform.position.x + lenghtOffset, startPoint.y + height);
                transform.position = newPosition;

                jumpTime += Time.deltaTime;
             
                if (!_collisionDetector.IsCollide && hasStartCollisions)
                    hasStartCollisions = false;
                
                yield return null;
            }
            
            yield break;

            bool inAir() => !_isGrounded || (_isGrounded && hasStartCollisions);
        }
    }
}
