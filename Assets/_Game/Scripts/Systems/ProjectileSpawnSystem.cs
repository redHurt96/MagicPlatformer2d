using Between;
using Leopotam.Ecs;
using RH.Game.Components;
using RH.Game.Enums;
using RH.Game.Services;
using System;
using UnityEngine;

namespace RH.Game.Systems
{
    public class ProjectileSpawnSystem : IEcsRunSystem
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
            InitProjectileComponent(ref entity);
        }

        private void InitFireballComponent(Vector2 from, Vector2 to, ref EcsEntity entity)
        {
            MovableSpawnSystem.Init(ref entity, _staticData.FireballPrefab, GameCamera.ScreenToWorldPoint(from), _staticData.FireballSpeed);
            ref var fireball = ref entity.Get<MoveDirection>();
            fireball.Direction = (to - from).normalized;
        }

        private void InitProjectileComponent(ref EcsEntity entity)
        {
            entity.Get<Projectile>();
        }

        private void RemoveInputEntity(int j)
        {
            ref var entity = ref _touchFilter.GetEntity(j);
            entity.Destroy();
        }
    }
}