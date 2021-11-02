using UnityEngine;

namespace RH.Game.UI
{
    [RequireComponent(typeof(Joystick))]
    public class JoystickView : MonoBehaviour
    {
        [SerializeField] private Transform _background;
        [SerializeField] private Transform _thumb;

        private Joystick _joystick;

        private void Start()
        {
            _joystick = GetComponent<Joystick>();

            _joystick.Setted += Set;
            _joystick.Moved += Move;
            _joystick.Removed += Remove;
        }

        private void OnDestroy()
        {
            _joystick.Setted -= Set;
            _joystick.Moved -= Move;
            _joystick.Removed -= Remove;
        }

        private void Set(Vector2 position)
        {
            _background.gameObject.SetActive(true);
            _thumb.gameObject.SetActive(true);

            _background.position = position;
            _thumb.position = position;
        }

        private void Move(Vector2 position)
        {
            _thumb.position = position;
        }

        private void Remove(Vector2 position)
        {
            _background.gameObject.SetActive(false);
            _thumb.gameObject.SetActive(false);
        }
    }
}