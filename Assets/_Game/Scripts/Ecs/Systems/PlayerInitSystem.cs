using Leopotam.Ecs;
using RH.Game.Components;
using RH.Game.Ecs;
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
            GameObject playerGameObject = Object.Instantiate(_staticData.PlayerPrefab, _sceneData.PlayerSpawnPosition, Quaternion.identity);
            ref Player player = ref _world.NewEntity().Get<Player>();
            
            player.Rigidbody = playerGameObject.GetComponent<Rigidbody2D>();
            player.SurfaceSlider = playerGameObject.GetComponent<SurfaceSlider>();
            player.GroundDetector = playerGameObject.GetComponent<GroundDetector>();

            _sceneData.Camera.Follow = playerGameObject.transform;
        }
    }
}