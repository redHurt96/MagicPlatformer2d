using UnityEngine;
using UnityEngine.UI;

namespace RH.Game.UI
{
    [RequireComponent(typeof(MoveJumpJoystick), typeof(Image))]
    public class JoystickFeedbackView : MonoBehaviour
    {
        [SerializeField] private Color _moveColor;
        [SerializeField] private Color _jumpColor;
        [SerializeField] private Color _defaultColor;

        private MoveJumpJoystick _joystick;
        private Image _image;

        private void Awake()
        {
            _joystick = GetComponent<MoveJumpJoystick>();
            _image = GetComponent<Image>();

            _joystick.OnMove += HighlightOnMove;
            _joystick.OnJump += HighlightOnJump;
            _joystick.OnStop += HideHightlight;
        }

        private void OnDestroy()
        {
            _joystick.OnMove -= HighlightOnMove;
            _joystick.OnJump -= HighlightOnJump;
            _joystick.OnStop -= HideHightlight;
        }

        private void HighlightOnJump() => _image.color = _jumpColor;
        private void HighlightOnMove() => _image.color = _moveColor;
        private void HideHightlight() => _image.color = _defaultColor;
    }
}