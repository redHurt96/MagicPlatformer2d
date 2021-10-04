using UnityEngine;
using Leopotam.Ecs;
using RH.Game.Components;

namespace RH.Game.Systems
{
    sealed class KeyboardJumpInputSystem : IEcsRunSystem
    {
        private EcsFilter<Player, Grounded> _playerFilter;

        void IEcsRunSystem.Run ()
        {
            foreach (int i in _playerFilter)
            {
                ref EcsEntity playerEntity = ref _playerFilter.GetEntity(in i);

                if (Input.GetKeyDown(KeyCode.Space))
                    AddJumpComponent(ref playerEntity);
            }
        }

        private static void AddJumpComponent(ref EcsEntity playerEntity)
        {
            Jump jump = playerEntity.Get<Jump>();
            jump.StartPosition = playerEntity.Get<Player>().Rigidbody.position;
        }
    }
}