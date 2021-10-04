using UnityEngine;
using Leopotam.Ecs;
using RH.Game.Components;

namespace RH.Game.Systems
{
    sealed class KeyboardDirectionInputSystem : IEcsRunSystem
    {
        private const string HORIZONTAL = "Horizontal";
        
        private EcsFilter<Player> _playerFilter;

        void IEcsRunSystem.Run ()
        {
            var value = Input.GetAxis(HORIZONTAL);

            foreach (int i in _playerFilter)
            {
                ref EcsEntity playerEntity = ref _playerFilter.GetEntity(in i);
            
                if (!Mathf.Approximately(value, 0f))
                    playerEntity.Get<InputDirection>().Direction = value;
            }

        }
    }
}