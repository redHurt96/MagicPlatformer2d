using System;
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
        private float _direction => KeyboardInput.Direction * _settings.PlayerSpeed * _settings.FallAirControlPercent;
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

        private void FixedUpdate()
        {
            if (_isPerformFalling && !_detector.IsCollide)
                _rigidbody.velocity = new Vector2(_direction, _rigidbody.velocity.y);
        }

        private IEnumerator PerformFall()
        {
            _isPerformFalling = true;
            _material.friction = 0f;

            yield return new WaitWhile(() => _isFall);

            _material.friction = _defaultMaterialFriction;
            _isPerformFalling = false;
            _rigidbody.velocity = new Vector2(0f, _rigidbody.velocity.y);

            yield break;
        }
    }
}
