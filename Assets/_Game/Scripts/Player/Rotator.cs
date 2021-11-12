using RH.Game.Input;
using UnityEngine;

namespace RH.Game.Player
{
    public class Rotator : MonoBehaviour
    {
        private void Update()
        {
            var direction = MovementInputService.MoveDirection.x;

            if (Mathf.Approximately(direction, 0f))
                return;

            transform.localScale = new Vector3(Mathf.Sign(direction), 1, 1);
        }
    }
}