using Leopotam.Ecs;
using RH.Game.Components;
using RH.Game.Ecs;
using UnityEngine;

namespace RH.Game.Systems
{
    sealed class PlayerJumpSystem : IEcsRunSystem
    {
        private readonly StaticData _staticData;

        private EcsFilter<Player, Jump> _filter;

        public void Run()
        {
            foreach (var i in _filter)
            {
                ref Player player = ref _filter.Get1(i);
                ref Jump jump = ref _filter.Get2(i);
                ref var entity = ref _filter.GetEntity(i);
                Vector2 targetPoint = CalculateTargetPoint(ref entity, ref player, ref jump);
                
                Move(ref player, targetPoint);
                UpdateProgress(ref jump);
            }
        }

        private Vector2 CalculateTargetPoint(ref EcsEntity entity, ref Player player, ref Jump jump)
        {
            float x = CalculateX(entity);
            float y = CalculateY(ref jump);

            return new Vector2(player.Rigidbody.position.x + x, jump.StartPosition.y + y);
        }

        private float CalculateX(EcsEntity entity)
        {
            float xOffset = 0f;

            if (entity.Has<InputDirection>())
                xOffset *= _staticData.Speed * entity.Get<InputDirection>().Direction;

            return xOffset;
        }

        private float CalculateY(ref Jump jump)
        {
            return _staticData.JumpCurve.Evaluate(jump.Time / _staticData.JumpTime) * _staticData.JumpHeight;
        }

        private void Move(ref Player player, Vector2 to)
        {
            player.Rigidbody.MovePosition(to);
        }

        private void UpdateProgress(ref Jump jump)
        {
            jump.Time += Time.deltaTime;
        }
    }
}