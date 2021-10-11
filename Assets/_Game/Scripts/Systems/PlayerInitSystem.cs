using Leopotam.Ecs;
using RH.Game.Components;
using RH.Game.Services;
using RH.Game.UnityComponents;
using UnityEngine;

namespace RH.Game.Systems
{
    sealed class PlayerInitSystem : IEcsInitSystem 
    {
        private readonly EcsWorld _world;
        private readonly StaticData _staticData;
        private readonly SceneData _sceneData;
        
        public void Init()
        {
            var playerEntity = _world.NewEntity();
            playerEntity.Get<Player>();

            MovableSpawnSystem.Init(ref playerEntity, _staticData.PlayerPrefab, _sceneData.PlayerSpawnPosition, _staticData.Speed);
            _sceneData.Camera.Follow = playerEntity.Get<Movable>().Rigidbody.transform;
        }
    }
}