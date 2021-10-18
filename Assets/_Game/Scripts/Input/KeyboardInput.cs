using UnityEngine;
using Zenject;
using RH.Game.Player;

namespace RH.Game.Input
{
    public class KeyboardInput : MonoBehaviour
    {
        private const string AXIS_NAME = "Horizontal";

        private Mover _mover;
        private Jumper _jumper;

        [Inject]
        private void Construct(Mover mover, Jumper jumper)
        {
            _mover = mover;
            _jumper = jumper;
        }

        private void Update()
        {
            UpdateMovement();
            UpdateJump();
        }

        private void UpdateMovement()
        {
            float axis = UnityEngine.Input.GetAxis(AXIS_NAME);

            if (!Mathf.Approximately(axis, 0f))
                _mover.Move(axis);
        }

        private void UpdateJump()
        {
            if (UnityEngine.Input.GetKeyDown(KeyCode.Space))
                _jumper.Jump();
        }
    }
}