using System;
using UnityEngine;

namespace RH.Game.Data
{
    [Serializable]
    public class PlayerData
    {
        public float Speed;

        public AnimationCurve JumpCurve;
        public float JumpHeight;
    }
}