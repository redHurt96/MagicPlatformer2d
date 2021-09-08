using UnityEngine;
using RH.Utilities.Attributes;

namespace RH.Game.Settings
{
    [CreateAssetMenu(fileName = "New PrototypeSettings", menuName = "Game/PrototypeSettings", order = 0)]
    public class PrototypeSettings : ScriptableObject
    {
        [Header("Player settings")]
        [SerializeField] private float _playerSpeed;
        [HideInInspector] public float PlayerSpeed => _playerSpeed * 2f;
        public AnimationCurve JumpCurve;
        public float JumpHeight;
        public float JumpLenght;
        [Range(0,1)] public float AirControlPercent;
        [Range(0,1)] public float FallAirControlPercent;
        public float JumpTime;
        
        [Header("Dev stuff")]
        [ReadOnly] public float BodyFriction = 1000;
        
        public static PrototypeSettings Instance { get; private set; }

        public void Init()
        {
            Instance = this;
        }
    }
}