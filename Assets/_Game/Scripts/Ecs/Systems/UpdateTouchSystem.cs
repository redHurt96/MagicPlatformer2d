using UnityEngine;
using Leopotam.Ecs;
using RH.Game.Components;

namespace RH.Game.Systems
{
    public class UpdateTouchSystem : IEcsRunSystem
    {
        private EcsFilter<TouchInput> _filter;

        public void Run()
        {
            foreach (int i in _filter)
                _filter.Get1(i).Points.Add(Input.mousePosition);
        }
    }
}