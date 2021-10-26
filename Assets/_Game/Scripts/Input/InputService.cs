using UnityEngine;
using System;

namespace RH.Game.Input
{
    public static class InputService
    {
        public static event Action OnJump;

        public static Vector2 MoveDirection { get; private set; }

        public static void SetDirection(float direction, IInputServiceInvoker invoker)
        {
            MoveDirection = new Vector2(direction, 0f);
        }

        public static void Jump(IInputServiceInvoker invoker)
        {
            OnJump?.Invoke();
        }
    }
}