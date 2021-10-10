using UnityEngine;
using Sirenix.OdinInspector;
using RH.Game.Enums;

namespace RH.Game.Services
{
    [CreateAssetMenu(fileName = "New StaticData", menuName = "Game/StaticData", order = 0)]
    public class StaticData : ScriptableObject
    {
        [AssetsOnly] public GameObject PlayerPrefab;

        [Space]

        public float Speed;
        public AnimationCurve JumpCurve;
        public float JumpHeight;
        public float JumpTime;
        public float JumpTreshhold;

        [Space]

        public SpellType DefaultSpell;
    }
}