using UnityEngine;
using Leopotam.Ecs;
using RH.Game.Systems;
using RH.Game.UnityComponents;
using RH.Game.Services;

namespace RH.Game
{
    sealed class EcsStartup : MonoBehaviour
    {
        [SerializeField] private StaticData _staticData;
        [SerializeField] private SceneData _sceneData;
        
        private EcsWorld _world;
        private EcsSystems _systems;

        private void Start()
        {
            _world = new EcsWorld();
            _systems = new EcsSystems(_world);
            
#if UNITY_EDITOR
            Leopotam.Ecs.UnityIntegration.EcsWorldObserver.Create(_world);
            Leopotam.Ecs.UnityIntegration.EcsSystemsObserver.Create(_systems);
#endif

            _systems
                .Add(new PlayerInitSystem())
                .Add(new PlayerGroundedSystem())
                .Add(new MovableStartJumpSystem())
                .Add(new JumpSystem())
                .Add(new KeyboardInputSystem())
                .Add(new MoveSystem())
                .Add(new StartTouchSystem())
                .Add(new UpdateTouchSystem())
                .Add(new FinishTouchSystem())
                .Inject(_staticData)
                .Inject(_sceneData)
                .Init();
        }

        private void Update () 
        {
            _systems?.Run ();
        }

        private void OnDestroy () 
        {
            if (_systems != null) 
            {
                _systems.Destroy();
                _systems = null;
                
                _world.Destroy();
                _world = null;
            }
        }
    }
}