using Leopotam.Ecs;
using RH.Game.Ecs.Systems;
using RH.Game.Ecs.UnityComponents;
using RH.Game.Settings;
using UnityEngine;

namespace RH.Game.Ecs
{
    sealed class EcsStartup : MonoBehaviour
    {
        [SerializeField] private StaticData _staticData;
        [SerializeField] private SceneData _sceneData;
        
        private EcsWorld _world;
        private EcsSystems _systems;

        private void Start () 
        {
            _world = new EcsWorld ();
            _systems = new EcsSystems (_world);
            
#if UNITY_EDITOR
            Leopotam.Ecs.UnityIntegration.EcsWorldObserver.Create (_world);
            Leopotam.Ecs.UnityIntegration.EcsSystemsObserver.Create (_systems);
#endif
            _systems
                .Add(new PlayerSpawnSystem())
                .Inject(_staticData)
                .Inject(_sceneData)
                // register your systems here, for example:
                // .Add (new TestSystem1 ())
                // .Add (new TestSystem2 ())
                
                // register one-frame components (order is important), for example:
                // .OneFrame<TestComponent1> ()
                // .OneFrame<TestComponent2> ()
                
                // inject service instances here (order doesn't important), for example:
                // .Inject (new CameraService ())
                // .Inject (new NavMeshSupport ())
                .Init ();
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