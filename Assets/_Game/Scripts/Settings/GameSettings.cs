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
        public float JoystickJumpAngle;

        [Header("Spells")]
        public CastType DefaultCastType;

        [Header("Fireball spell")] 
        public Projectile.ProjectileData ProjectileData;
        public float ProjectileInputLenght;
        public float ProjectileCastDistanceFromPlayer;

        [Header("Shield spell")] 
        public float ShieldLifeTime;
        [AssetsOnly] public Shield ShieldPrefab;
        public float ShieldsLenght;
        public float ShieldInputLenght;

        [Header("Sword hit")]
        public float SwordHitTime;

        [Header("Push spell")]
        public Vector2 PushAreaSize;
        public float PushForce;

        [Header("Input UI")]
        public InputUiCreator.InputType MoveUiType;

        [Header("Mana")]
        public bool UseManaToDraw;
        public float ManaCostPerUnit;
        public float ManaMaxValue;
        public float ManaRecoveryPerSecond;

        [Header("Dev stuff")]
        public bool InputLogEnabled;
        public bool JumpGizmosEnabled;
        public bool PushPerformerLogsEnabled;
        public float LineAngleTreshhold;

        public static GameSettings Instance { get; private set; }

        public void Init()
        {
            Instance = this;
        }
    }
}