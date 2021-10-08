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
            var playerInstance = MovableSpawnSystem.Spawn(_staticData.PlayerPrefab, _sceneData.PlayerSpawnPosition);
            var playerEntity = _world.NewEntity();
            playerEntity.Get<Player>();
            
            ref var movable = ref playerEntity.Get<Movable>();

            movable.Rigidbody = playerInstance.GetComponent<Rigidbody2D>();
            movable.GroundDetector = playerInstance.GetComponent<GroundDetector>();
            movable.Speed = _staticData.Speed;

            _sceneData.Camera.Follow = movable.Rigidbody.transform;
        }
    }
}