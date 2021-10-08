using UnityEngine;
using Leopotam.Ecs;
using RH.Game.Components;

namespace RH.Game.Systems
{
    sealed class KeyboardInputSystem : IEcsRunSystem 
    {
        private const string HORIZONTAL = "Horizontal";

        private EcsFilter<Player> _filter;
        
        void IEcsRunSystem.Run()
        {
            foreach (int i in _filter)
            {
                ref EcsEntity playerEntity = ref _filter.GetEntity(i);

                CheckAxis(ref playerEntity);
                CheckJump(ref playerEntity);
            }
        }

        private void CheckAxis(ref EcsEntity playerEntity)
        {
            float axis = Input.GetAxis(HORIZONTAL);

            if (!Mathf.Approximately(0f, axis))
                playerEntity.Get<MoveDirection>().Direction = axis;
        }

        private void CheckJump(ref EcsEntity playerEntity)
        {
            if (Input.GetKeyDown(KeyCode.Space))
                playerEntity.Get<Jump>();
        }
    }
}