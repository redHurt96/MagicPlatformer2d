using System.Collections;
using RH.Game.Settings;
using RH.Game.UserInput;
using UnityEngine;

namespace RH.Game.Player
{
    public class FallPerformer : MonoBehaviour
    {
        [SerializeField] private Rigidbody2D _rigidbody;
        [SerializeField] private CurveJumper _jumper;
        [SerializeField] private CollisionDetector _detector;

        private bool _isFall => !_jumper.IsJumping && !_detector.IsGrounded;
        private PrototypeSettings _settings => PrototypeSettings.Instance;
        private float _direction => KeyboardInput.Direction * _settings.AirControlPercent * _settings.FallSideAcceleration;
        private float _playerSpeed => _settings.PlayerSpeed;
        private float _defaultMaterialFriction => _settings.BodyFriction;
        private PhysicsMaterial2D _material => _rigidbody.sharedMaterial;

        private bool _isPerformFalling;

        private void Update()
        {
            if (_isFall && !_isPerformFalling)
                StartCoroutine(PerformFall());
            else if (!_isFall && Mathf.Approximately(_material.friction, 0f))
                _material.friction = _defaultMaterialFriction;
        }

        private IEnumerator PerformFall()
        {
            _isPerformFalling = true;
            _material.friction = 0f;

            while (_isFall)
            {
                if (!_detector.IsCollide)
                    MovePlayer();
                
                yield return null;
            }

            _material.friction = _defaultMaterialFriction;
            _isPerformFalling = false;
            
            yield break;
        }

        private void MovePlayer()
        {
            _rigidbody.AddForce(new Vector2(_direction, 0f));
            
            var velocity = _rigidbody.velocity; 
            _rigidbody.velocity = new Vector2(Mathf.Clamp(velocity.x, 0f, _playerSpeed), velocity.y);
        }
    }
}
