using Leopotam.Ecs;
using RH.Game.Ecs.UnityComponents;
using RH.Game.Settings;
using UnityEngine;

namespace RH.Game.Ecs.Systems 
{
    sealed class PlayerSpawnSystem : IEcsInitSystem 
    {
        private readonly EcsWorld _world;
        private readonly StaticData _staticData;
        private readonly SceneData _sceneData;
        
        public void Init()
        {
            MonoBehaviour.Instantiate(_staticData.PlayerPrefab, _sceneData.PlayerSpawnPosition, Quaternion.identity);
        }
    }
}