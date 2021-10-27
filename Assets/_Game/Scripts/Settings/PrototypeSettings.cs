using UnityEngine;
using Sirenix.OdinInspector;
using Between.SpellsEffects.ShieldSpell;
using RH.Game.Projectiles;

namespace RH.Game.Settings
{
    [CreateAssetMenu(fileName = "New PrototypeSettings", menuName = "Game/PrototypeSettings", order = 0)]
    public class PrototypeSettings : ScriptableObject
    {
        #region PLAYER_SETTINGS

        [Header("Movement settings")]

        public float MoveSpeed;
        public AnimationCurve JumpCurve;
        public float JumpHeight;
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
        public bool EnableInputLog;

        public static PrototypeSettings Instance { get; private set; }

        public void Init()
        {
            Instance = this;
        }
    }
}