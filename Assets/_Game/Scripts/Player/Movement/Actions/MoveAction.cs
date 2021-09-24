using System.Collections;
using System.Collections.Generic;
using RH.Game.Input;
using RH.Game.Settings;
using RH.Utilities.StateMachine2;
using UnityEngine;

namespace RH.Game.Player.Movement
{
    public class MoveAction : Action
    {
        private readonly Transform _transform;
        private readonly SurfaceSlider _surfaceSlider;

        private float _speed => PrototypeSettings.Instance.PlayerSpeed;

        public MoveAction(Transform transform, SurfaceSlider surfaceSlider)
        {
            _surfaceSlider = surfaceSlider;
            _transform = transform;
        }
        
        public override void Execute()
        {
            Vector2 moveOffset = CalculateMoveOffset();
            _transform.Translate(moveOffset);
        }
        
        private Vector2 CalculateMoveOffset()
        {
            Vector2 direction = new Vector2(KeyboardInput.Direction, 0f);
            Vector2 directionAlongSurface = _surfaceSlider.Project(direction.normalized);
            return directionAlongSurface * (_speed * Time.deltaTime);
        }
    }
}
