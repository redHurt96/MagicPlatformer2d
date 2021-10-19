using Leopotam.Ecs;
using RH.Game.Components;
using UnityEngine;

namespace RH.Game.Systems
{
    public class ProjectileCheckCollisionsSystem : IEcsRunSystem
    {
        private EcsFilter<Movable, Projectile> _filter;

        public void Run()
        {
            foreach (int i in _filter)
            {
                ref var movable = ref _filter.Get1(i);
                TryDestroy(i, ref movable);
            }
        }

        private void TryDestroy(int i, ref Movable movable)
        {
            if (movable.CollisionDetector.IsCollided)
            {
                GameObject.Destroy(movable.Rigidbody.gameObject);
                _filter.GetEntity(i).Destroy();
            }
        }
    }
}