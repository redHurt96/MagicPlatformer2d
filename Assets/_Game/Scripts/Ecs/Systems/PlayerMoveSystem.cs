using Leopotam.Ecs;
using RH.Game.Components;
using RH.Game.Ecs;
using UnityEngine;

namespace RH.Game.Systems 
{
    sealed class PlayerMoveSystem : IEcsRunSystem 
    {
        private readonly StaticData _staticData;
        private EcsFilter<Player, InputDirection, Grounded> _playerFilter;

        void IEcsRunSystem.Run () 
        {
            foreach (int i in _playerFilter)
            {
                ref var playerEntity = ref _playerFilter.GetEntity(i);
                ref var player = ref _playerFilter.Get1(i);
                ref var direction = ref _playerFilter.Get2(i);

                Move(ref player, ref direction);
                DeleteInputComponent(ref playerEntity);
            }
        }

        private void Move(ref Player player, ref InputDirection direction)
        {
            var offset = player.SurfaceSlider.Project(new Vector2(direction.Direction, 0f));
            player.Rigidbody.MovePosition(player.Rigidbody.position + offset * _staticData.Speed);
        }
        
        private static void DeleteInputComponent(ref EcsEntity playerEntity)
        {
            playerEntity.Del<InputDirection>();
        }
    }
}