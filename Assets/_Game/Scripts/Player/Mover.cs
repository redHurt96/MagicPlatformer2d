using UnityEngine;
using RH.Game.Settings;
using RH.Game.Input;

namespace RH.Game.Player
{
    public class Mover : MonoBehaviour
    {
        [SerializeField] private SurfaceSlider _surfaceSlider;
        [SerializeField] private CollisionDetector _collisionDetector;

        private float _speed => PrototypeSettings.Instance.PlayerSpeed;

        private void Start()
        {
            KeyboardInput.OnInput += Move;
        }

        private void OnDestroy()
        {
            KeyboardInput.OnInput -= Move;
        }

        private void Move(Vector2 direction)
        {
            if (!_collisionDetector.IsGrounded)
                return;

            Vector2 moveOffset = CalculateMoveOffset(direction);
            transform.Translate(moveOffset);
        }

        private Vector2 CalculateMoveOffset(Vector2 direction)
        {
            Vector2 directionAlongSurface = _surfaceSlider.Project(direction.normalized);
            return directionAlongSurface * (_speed * Time.deltaTime);
        }
    }
}