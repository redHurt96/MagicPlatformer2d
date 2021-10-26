using UnityEngine;

namespace RH.Game.Input
{
    public class KeyboardInputInvoker : MonoBehaviour, IInputServiceInvoker
    {
        private const string AXIS_NAME = "Horizontal";

        private void Awake()
        {
#if !UNITY_EDITOR
            Destroy(gameObject);
#endif
        }

        private void Update()
        {
            UpdateMoveDirection();
            UpdateJumpInput();
        }

        private void UpdateMoveDirection()
        {
            var axis = UnityEngine.Input.GetAxis(AXIS_NAME);
            InputService.SetDirection(axis, this);
        }

        private void UpdateJumpInput()
        {
            if (UnityEngine.Input.GetKeyDown(KeyCode.Space))
                InputService.Jump(this);
        }
    }
}