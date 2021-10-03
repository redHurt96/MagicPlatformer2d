using System;
using System.Collections;
using RH.Game.Settings;
using RH.Game.Input;
using UnityEngine;

namespace RH.Game.Player
{
    public class FallPerformer : MonoBehaviour
    {
        [SerializeField] private Rigidbody2D _rigidbody;
        [SerializeField] private CurveJumper _jumper;
        [SerializeField] private CollisionDetector _detector;

        private bool _isFall => !_jumper.IsJumping && !_detector.IsGrounded;
        private StaticData _settings => StaticData.Instance;
        private float _direction => KeyboardInput.Direction * _settings.PlayerSpeed * _settings.FallAirControlPercent;
        private float _defaultMaterialFriction => _settings.BodyFriction;
        private bool _isPerformFalling;

        private void Update()
        {
            if (_isFall && !_isPerformFalling)
                StartCoroutine(PerformFall());
        }

        private void FixedUpdate()
        {
            if (_isPerformFalling && !_detector.IsCollide)
                _rigidbody.velocity = new Vector2(_direction, _rigidbody.velocity.y);
        }

        private IEnumerator PerformFall()
        {
            _isPerformFalling = true;

            yield return new WaitWhile(() => _isFall);

            _isPerformFalling = false;
            _rigidbody.velocity = new Vector2(0f, _rigidbody.velocity.y);
        }
    }
}
