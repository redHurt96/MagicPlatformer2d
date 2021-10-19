using UnityEngine;
using Leopotam.Ecs;
using RH.Game.Components;
using RH.Game.Services;
using System;

namespace RH.Game.Systems
{
    public class JumpSystem : IEcsRunSystem
    {
        private readonly StaticData _staticData;
        private EcsFilter<Movable, Jump> _filter;

        public void Run()
        {
            foreach (int i in _filter)
            {
                ref var entity = ref _filter.GetEntity(i);
                ref var movable = ref _filter.Get1(i);
                ref var jump = ref entity.Get<Jump>();

                PerformJump(ref entity, ref movable, ref jump);
                DeleteJumpIfCan(ref entity, ref jump);
            }
        }

        private void PerformJump(ref EcsEntity entity, ref Movable movable, ref Jump jump)
        {
            Vector2 horizontalOffset = GetHorizontalOffset(ref entity, ref movable);

            float verticalPosition = jump.StartPosition.y + _staticData.JumpCurve.Evaluate(jump.Progress) * _staticData.JumpHeight;
            movable.Rigidbody.MovePosition(new Vector2(movable.Position.x + horizontalOffset.x, verticalPosition));

            jump.Progress += Time.deltaTime / _staticData.JumpTime;
        }

        private static Vector2 GetHorizontalOffset(ref EcsEntity entity, ref Movable movable)
        {
            Vector2 horizontalOffset = default;

            if (entity.Has<MoveDirection>())
                horizontalOffset = MoveSystem.GetOffset(ref movable, ref entity.Get<MoveDirection>());
            return horizontalOffset;
        }

        private void DeleteJumpIfCan(ref EcsEntity entity, ref Jump jump)
        {
            if (jump.Progress > _staticData.JumpCurve.length)
                entity.Del<Jump>();
        }
    }
}