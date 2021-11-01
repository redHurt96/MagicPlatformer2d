﻿using UnityEngine;
using System;

namespace RH.Game.Input
{
    public static class MovementInputService
    {
        public static event Action OnJump;

        public static Vector2 MoveDirection { get; private set; }
        public static bool HasInput { get; private set; }

        public static void SetDirection(float direction, IMovementInputServiceHandler by)
        {
            MoveDirection = new Vector2(direction, 0f);
            HasInput = !Mathf.Approximately(direction, 0f);
        }

        public static void Jump(IMovementInputServiceHandler invoker)
        {
            OnJump?.Invoke();
        }
    }
}