using System.Collections;
using System.Collections.Generic;
using RH.Game.Input;
using RH.Game.Settings;
using RH.Utilities.StateMachine2;
using UnityEngine;

namespace RH.Game.Player.Movement
{
    public class JumpAction : Action
    {
        private readonly Transform _transform;
        
        private PrototypeSettings _settings => PrototypeSettings.Instance;
        private AnimationCurve _curve => _settings.JumpCurve;
        private float _height => _settings.JumpHeight;
        private float _lenght => _settings.JumpLenght;
        private float _airControlPercent => _settings.AirControlPercent;
        private float _time => _settings.JumpTime;
        
        private float _startDirection;
        private bool _hasStartCollisions = true;
        private float _jumpTime = 0f;
        private Vector2 _startPoint;
        
        public JumpAction(Transform transform)
        {
            _transform = transform;
        }
        
        public override void Prepare()
        {
            _jumpTime = 0f;
            _hasStartCollisions = true;
            _startDirection = KeyboardInput.Direction;
            _startPoint = _transform.position;
        }

        public override void Execute()
        {
            _transform.position = new Vector2(CalculateHorizontalPosition(), CalculateVerticalPosition());
            _jumpTime += Time.deltaTime;
        }

        private float CalculateHorizontalPosition()
        {
            var inputCoefficient = Mathf.Lerp(_startDirection, KeyboardInput.Direction, _airControlPercent);
            return _transform.position.x + _lenght * Time.deltaTime * inputCoefficient;
        }
            
        private float CalculateVerticalPosition()
        {                
            var curvePoint = _curve.Evaluate(_jumpTime / _time);
            var height = curvePoint * _height;
            return _startPoint.y + height;
        }
    }
}
