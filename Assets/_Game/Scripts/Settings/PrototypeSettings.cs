using RH.Game.Projectiles;
using UnityEngine;
using RH.Utilities.Attributes;

namespace RH.Game.Settings
{
    [CreateAssetMenu(fileName = "New PrototypeSettings", menuName = "Game/PrototypeSettings", order = 0)]
    public class PrototypeSettings : ScriptableObject
    {
        #region PLAYER_SETTINGS

        [Header("Player settings")]
        [SerializeField] private float _playerSpeed;
        [HideInInspector] public float PlayerSpeed => _playerSpeed * 2f;
        public AnimationCurve JumpCurve;
        public float JumpHeight;
        public float JumpLenght;
        [Range(0,1)] public float AirControlPercent;
        [Range(0,1)] public float FallAirControlPercent;
        public float JumpTime;

        #endregion

        [Header("Fireball spell")] 
        public Projectile.ProjectileData ProjectileData;

        [Header("Shield spell")] 
        public float ShieldLifeTime;
        
        [Header("Dev stuff")]
        [ReadOnly] public float BodyFriction = 1000;
        public bool EnableInputLog;
        
        public static PrototypeSettings Instance { get; private set; }

        public void Init()
        {
            Instance = this;
        }
    }
}