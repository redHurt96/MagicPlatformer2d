using UnityEngine;
using Sirenix.OdinInspector;
using Between.SpellsEffects.ShieldSpell;
using RH.Game.Projectiles;

namespace RH.Game.Settings
{
    [CreateAssetMenu(fileName = "New PrototypeSettings", menuName = "Game/PrototypeSettings", order = 0)]
    public class GameSettings : ScriptableObject
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
        public float ProjectileInputLenght;

        [Header("Shield spell")] 
        public float ShieldLifeTime;
        [AssetsOnly] public Shield ShieldPrefab;
        public float ShieldsLenght;
        public float ShieldInputLenght;

        [Header("Dev stuff")]
        public bool EnableInputLog;
        public bool EnableJumpGizmos;

        public static GameSettings Instance { get; private set; }

        public void Init()
        {
            Instance = this;
        }
    }
}