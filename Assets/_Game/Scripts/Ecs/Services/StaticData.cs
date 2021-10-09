using UnityEngine;
using Sirenix.OdinInspector;

namespace RH.Game.Services
{
    [CreateAssetMenu(fileName = "New StaticData", menuName = "Game/StaticData", order = 0)]
    public class StaticData : ScriptableObject
    {
        [Header("ECS")] 
        [AssetsOnly] public GameObject PlayerPrefab;

        [Space]

        public float Speed;
        public AnimationCurve JumpCurve;
        public float JumpHeight;
        public float JumpTime;
        public float JumpTreshhold;
    }
}