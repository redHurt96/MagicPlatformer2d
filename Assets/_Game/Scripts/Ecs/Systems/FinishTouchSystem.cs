using Leopotam.Ecs;
using RH.Game.Components;

namespace RH.Game.Systems
{
    public class FinishTouchSystem : IEcsRunSystem
    {
        private EcsFilter<TouchInput> _filter;

        public void Run()
        {
            foreach (int i in _filter)
                _filter.GetEntity(i).Get<FinishInput>();
        }
    }
}