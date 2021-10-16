using Leopotam.Ecs;
using RH.Game.Components;
using UnityEngine;

namespace RH.Game.Systems
{
    public class FireballCheckCollisionsSystem : IEcsRunSystem
    {
        private EcsFilter<Fireball, Movable> _filter;

        public void Run()
        {
            foreach (int i in _filter)
            {
                ref var movable = ref _filter.Get2(i);
                Destroy(i, ref movable);
            }
        }

        private void Destroy(int i, ref Movable movable)
        {
            if (movable.CollisionDetector.IsCollided)
            {
                GameObject.Destroy(movable.Rigidbody.gameObject);
                _filter.GetEntity(i).Destroy();
            }
        }
    }

    public class FireballMoveSystem : IEcsRunSystem
    {
        private EcsFilter<Fireball, Movable> _filter;

        public void Run()
        {
            foreach (int i in _filter)
                Move(ref _filter.Get1(i), ref _filter.Get2(i));
        }

        private void Move(ref Fireball fireball, ref Movable movable)
        {
            movable.Rigidbody.MovePosition(movable.Rigidbody.position + fireball.Direction * movable.Speed);
        }
    }
}