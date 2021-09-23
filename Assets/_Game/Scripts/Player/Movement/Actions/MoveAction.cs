using RH.Game.Input;
using UnityEngine;
using RH.Game.Settings;
using RH.Utilities.StateMachine2;

namespace RH.Game.Player.Movement.Actions
{
    public class MoveAction : Action
    {
        private Rigidbody2D _rigidbody;
        private SurfaceSlider _surfaceSlider;
        private CollisionDetector _collisionDetector;
        
        private float _speed => PrototypeSettings.Instance.PlayerSpeed;
        private Vector2 _inputDirection => new Vector2(KeyboardInput.Direction, 0f);
        
        public MoveAction(Rigidbody2D rigidbody, SurfaceSlider surfaceSlider, CollisionDetector collisionDetector)
        {
            _rigidbody = rigidbody;
            _surfaceSlider = surfaceSlider;
            _collisionDetector = collisionDetector;
        }
        
        public override void Update()
        {
            if (_inputDirection == Vector2.zero || !_collisionDetector.IsGrounded)
                return;

            Vector2 directionAlongSurface = _surfaceSlider.Project(_inputDirection.normalized);
            Vector2 offset = directionAlongSurface * (_speed * Time.deltaTime);

            _rigidbody.MovePosition(_rigidbody.position + offset);
        }
    }
}