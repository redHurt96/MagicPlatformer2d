using UnityEngine;

namespace RH.Game.UI
{
    [RequireComponent(typeof(BaseJoystick))]
    public class JoystickView : MonoBehaviour
    {
        [SerializeField] private Transform _background;
        [SerializeField] private Transform _thumb;

        [SerializeField] private bool _isClamped;
        [SerializeField] private float _clampRadius;

        private BaseJoystick _joystick;
        private Vector2 _beginPosition;

        private void Start()
        {
            _joystick = GetComponent<BaseJoystick>();

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
            _beginPosition = position;

            _background.gameObject.SetActive(true);
            _thumb.gameObject.SetActive(true);

            _background.position = position;
            _thumb.position = position;
        }

        private void Move(Vector2 position)
        {
            _thumb.position = CalculateThumbPosition(position);
        }

        private void Remove(Vector2 position)
        {
            _background.gameObject.SetActive(false);
            _thumb.gameObject.SetActive(false);
        }

        private Vector2 CalculateThumbPosition(Vector2 from) =>
            _isClamped ? _beginPosition + CalculateClampedOffset(from) : from;

        private Vector2 CalculateClampedOffset(Vector2 from)
        {
            Vector2 offset = from - _beginPosition;

            if (offset.sqrMagnitude > Mathf.Pow(_clampRadius, 2))
                offset = offset.normalized * _clampRadius;

            return offset;
        }
    }
}