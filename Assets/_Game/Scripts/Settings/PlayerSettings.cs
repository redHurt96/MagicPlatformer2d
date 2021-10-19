using System;
using UnityEngine;

namespace RH.Game.Settings
{
    [Serializable]
    public class PlayerSettings
    {
        public float Speed;

        public AnimationCurve JumpCurve;
        public float JumpHeight;
    }
}