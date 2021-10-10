using Leopotam.Ecs;
using RH.Game.Components;
using UnityEngine;

namespace RH.Game.Systems
{
    public class FinishTouchSystem : IEcsRunSystem
    {
        private EcsFilter<TouchInput> _filter;

        public void Run()
        {
            foreach (int i in _filter)
            {
                if (Input.GetMouseButtonUp(0))
                    _filter.GetEntity(i).Get<FinishInput>();
            }
        }
    }
}