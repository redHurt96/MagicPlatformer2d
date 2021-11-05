using UnityEngine;
using Sirenix.OdinInspector;
using Between.SpellsEffects.ShieldSpell;
using RH.Game.Projectiles;
using RH.Game.Infrastructure;
using RH.Game.Spells;

namespace RH.Game.Settings
{
    [CreateAssetMenu(fileName = "New PrototypeSettings", menuName = "Game/PrototypeSettings", order = 0)]
    public class GameSettings : ScriptableObject
    {
        [Header("Movement settings")]

        public float MoveSpeed;
        public AnimationCurve JumpCurve;
        public float JumpHeight;
        [Range(0,1)] public float AirControlPercent;
        [Range(0,1)] public float FallAirControlPercent;
        public float JumpTime;
        public JumpMovementType JumpMovementType;

        [Header("Spells")]
        public SpellsCollection.CastType CastType;

        [Header("Fireball spell")] 
        public Projectile.ProjectileData ProjectileData;
        public float ProjectileInputLenght;

        [Header("Shield spell")] 
        public float ShieldLifeTime;
        [AssetsOnly] public Shield ShieldPrefab;
        public float ShieldsLenght;
        public float ShieldInputLenght;

        [Header("Input UI")]
        public InputUiCreator.InputType MoveUiType;

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