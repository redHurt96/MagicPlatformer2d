using UnityEngine;
using RH.Utilities.Attributes;

namespace RH.Game.Settings
{
    [CreateAssetMenu(fileName = "New PrototypeSettings", menuName = "Game/PrototypeSettings", order = 0)]
    public class PrototypeSettings : ScriptableObject
    {
        [Header("Player settings")]
        public float PlayerSpeed;
        public AnimationCurve JumpCurve;
        public float JumpHeight;
        public float JumpLenght;
        [Range(0,1)] public float AirControlPercent;
        public float JumpTime;
        public float FallSideAcceleration;
        [ReadOnly] public float BodyFriction = 1000;
        
        public static PrototypeSettings Instance { get; private set; }

        public void Init()
        {
            Instance = this;
        }
        
    }
}