using UnityEngine;
using Leopotam.Ecs;
using RH.Game.Components;

namespace RH.Game.Systems
{
    sealed class MoveSystem : IEcsRunSystem 
    {
        private EcsFilter<Movable, MoveDirection> _filter;

        void IEcsRunSystem.Run()
        {
            foreach (int i in _filter)
            {
                ref var movable = ref _filter.Get1(i);
                ref var direction = ref _filter.Get2(i);

                Move(ref movable, ref direction);
                RemoveMoveDirection(i);
            }
        }

        private void Move(ref Movable movable, ref MoveDirection moveDirection)
        {
            movable.Rigidbody.MovePosition(movable.Position + Vector2.right * moveDirection.Direction * movable.Speed);
        }

        private void RemoveMoveDirection(int byEntityIndex)
        {
            _filter.GetEntity(byEntityIndex).Del<MoveDirection>();
        }
    }
}