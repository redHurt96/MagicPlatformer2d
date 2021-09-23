using Between.SpellsEffects.ShieldSpell;
using RH.Game.Projectiles;
using UnityEngine;
using Sirenix.OdinInspector;
using UnityEngine.Serialization;

namespace RH.Game.Settings
{
    [CreateAssetMenu(fileName = "New PrototypeSettings", menuName = "Game/PrototypeSettings", order = 0)]
    public class PrototypeSettings : ScriptableObject
    {
        #region PLAYER_SETTINGS

        [Header("Player settings")]
        [SerializeField] private float _playerSpeed;
        public float PlayerSpeed => _playerSpeed * 2f;
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
        [AssetsOnly] public Shield ShieldPrefab;
        public float ShieldsLenght;
        
        [Header("Dev stuff")]
        public float BodyFriction = 1000;
        public bool EnableInputLog;
        public bool EnableMovementGizmos;
        
        public static PrototypeSettings Instance { get; private set; }

        public void Init()
        {
            Instance = this;
        }
    }
}