using Between;
using Leopotam.Ecs;
using RH.Game.Components;
using RH.Game.Enums;
using RH.Game.Services;
using UnityEngine;

namespace RH.Game.Systems
{
    public class FireballSpawnSystem : IEcsRunSystem
    {
        private readonly StaticData _staticData;
        private readonly EcsWorld _world;
        
        private EcsFilter<TouchInput, CanSpawnFireball> _touchFilter;
        
        public void Run()
        {
            foreach (int i in _touchFilter)
            {
                ref var touchInput = ref _touchFilter.Get1(i);
                Spawn(touchInput.Points[0], touchInput.Points[^1]);
                RemoveInputEntity(i);
            }
        }

        private void Spawn(Vector2 from, Vector2 to)
        {
            var entity = _world.NewEntity();
            InitFireballComponent(from, to, ref entity);
        }

        private void InitFireballComponent(Vector2 from, Vector2 to, ref EcsEntity entity)
        {
            var gameObject = GameObject.Instantiate(_staticData.FireballPrefab, GameCamera.ScreenToWorldPoint(from), Quaternion.identity);
            ref var fireball = ref entity.Get<Fireball>();

            fireball.Direction = (to - from).normalized;
            fireball.Rigidbody = gameObject.GetComponent<Rigidbody2D>();
            fireball.Speed = _staticData.FireballSpeed;
        }

        private void RemoveInputEntity(int j)
        {
            ref var entity = ref _touchFilter.GetEntity(j);
            entity.Destroy();
        }
    }
}