using RH.Game.Input;
using RH.Game.Settings;
using RH.Utilities.StateMachine2;
using UnityEngine;

namespace RH.Game.Player.Movement.Actions
{
    public class JumpAction : Action
    {
        public bool IsJumping { get; private set; }
        
        private readonly Rigidbody2D _rigidbody;

        private PrototypeSettings _settings => PrototypeSettings.Instance;
        private AnimationCurve _curve => _settings.JumpCurve;
        private float _height => _settings.JumpHeight;
        private float _lenght => _settings.JumpLenght;
        private float _airControlPercent => _settings.AirControlPercent;
        private float _time => _settings.JumpTime;

        private Vector2 _startPoint;
        private float _startDirection;
        private bool _hasStartCollisions;
        private float _jumpTime;

        public JumpAction(Rigidbody2D rigidbody)
        {
            _rigidbody = rigidbody;
        }

        public override void Prepare()
        {
            IsJumping = true;
            _startPoint = _rigidbody.position;
            _startDirection = KeyboardInput.Direction;
            _jumpTime = 0f;
        }

        public override void Update()
        {
            _rigidbody.MovePosition(new Vector2(_rigidbody.position.x + CalculateHorizontalOffset(), _startPoint.y + CalculateHeight()));
            _jumpTime += Time.deltaTime;
        }

        public override void Dispose()
        {
            _rigidbody.velocity = Vector2.zero;
            IsJumping = false;
        }
        
        private float CalculateHorizontalOffset()
        {
            var inputCoefficient = Mathf.Lerp(_startDirection, KeyboardInput.Direction, _airControlPercent);
            return _lenght * Time.deltaTime * inputCoefficient;
        }
        
        private float CalculateHeight()
        {                
            var curvePoint = _curve.Evaluate(_jumpTime / _time);
            var height = curvePoint * _height;
            return height;
        }
    }
}