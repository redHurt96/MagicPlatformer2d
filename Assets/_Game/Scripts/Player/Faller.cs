using System.Collections;
using UnityEngine;
using RH.Game.Settings;
using RH.Game.Input;

namespace RH.Game.Player
{
    public class Faller : MonoBehaviour
    {
        [SerializeField] private Rigidbody2D _rigidbody;
        [SerializeField] private Jumper _jumper;
        [SerializeField] private CollisionDetector _detector;

        private bool _isFall => !_jumper.IsJumping && !_detector.IsGrounded;
        private PrototypeSettings _settings => PrototypeSettings.Instance;
        private float _direction => KeyboardInput.Direction * _settings.PlayerSpeed * _settings.FallAirControlPercent;
        private bool IsPerformFalling => _fallCoroutine != null;

        private Coroutine _fallCoroutine;

        private void Update()
        {
            UpdateFallingVelocity();
            TryStartFalling();
        }

        private void TryStartFalling()
        {
            if (_isFall && !IsPerformFalling)
                _fallCoroutine = StartCoroutine(PerformFall());
        }

        private IEnumerator PerformFall()
        {
            yield return new WaitWhile(() => _isFall);
            _fallCoroutine = null;
        }

        private void UpdateFallingVelocity()
        {
            if (IsPerformFalling && !_detector.IsCollide)
                transform.Translate(new Vector2(_direction, _rigidbody.velocity.y) * Time.deltaTime);
        }
    }
}
