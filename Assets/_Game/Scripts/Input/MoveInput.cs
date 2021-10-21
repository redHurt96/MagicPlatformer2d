using UnityEngine;
using UnityEngine.InputSystem;
using RH.Game.Player;

namespace RH.Game.Input
{
    [RequireComponent(typeof(JumpPerformer))]
    public class MoveInput : MonoBehaviour
    {
        public static Vector2 Direction;

        private JumpPerformer _jumpPerformer;
        private PlayerInput _input;

        private void Awake()
        {
            _input = new PlayerInput();
            _jumpPerformer = GetComponent<JumpPerformer>();
        }

        private void OnEnable()
        {
            _input.Enable();
            _input.Player.Jump.performed += Jump;
        }

        private void OnDisable()
        {
            _input.Disable();
            _input.Player.Jump.performed -= Jump;
        }

        private void Update()
        {
            Direction = new Vector2(_input.Player.Move.ReadValue<float>(), 0f);
        }

        private void Jump(InputAction.CallbackContext obj)
        {
            _jumpPerformer.Jump();
        }
    }
}