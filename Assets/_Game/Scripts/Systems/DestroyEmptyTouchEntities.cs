using Leopotam.Ecs;
using RH.Game.Components;

namespace RH.Game.Systems
{
    public class DestroyEmptyTouchEntities : IEcsRunSystem
    {
        private EcsFilter<FinishInput> _filter;

        public void Run()
        {
            foreach (int i in _filter)
            {
                ref var entity = ref _filter.GetEntity(i);

                if (entity.GetComponentsCount() == 1)
                    entity.Destroy();
            }
        }
    }
}