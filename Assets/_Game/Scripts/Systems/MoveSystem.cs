using UnityEngine;
using Leopotam.Ecs;
using RH.Game.Components;

namespace RH.Game.Systems
{
    sealed class MoveSystem : IEcsRunSystem 
    {
        private EcsFilter<Movable, MoveDirection, Grounded> _filter;

        public void Run()
        {
            foreach (int i in _filter)
            {
                ref var movable = ref _filter.Get1(i);
                ref var direction = ref _filter.Get2(i);

                if (!_filter.GetEntity(i).Has<Jump>())
                    Move(ref movable, ref direction);
            }
        }

        public static Vector2 GetOffset(ref Movable movable, ref MoveDirection moveDirection) => Vector2.right * moveDirection.Direction * movable.Speed;

        private static Vector2 GetMoveVector(ref Movable movable, ref MoveDirection moveDirection) => movable.Position + GetOffset(ref movable, ref moveDirection);

        private static void Move(ref Movable movable, ref MoveDirection moveDirection) => movable.Rigidbody.MovePosition(GetMoveVector(ref movable, ref moveDirection));
    }
}