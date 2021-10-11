using Leopotam.Ecs;
using RH.Game.Components;

namespace RH.Game.Systems
{
    public class MovableStartJumpSystem : IEcsRunSystem
    {
        private EcsFilter<Movable, Grounded, CanJump> _filter;

        public void Run()
        {
            foreach (int i in _filter)
            {
                ref var entity = ref _filter.GetEntity(i);

                RemoveComponents(ref entity);
                AddJumpComponent(ref entity);
            }
        }

        private static void RemoveComponents(ref EcsEntity entity)
        {
            entity.Del<Grounded>();
            entity.Del<CanJump>();
        }
        
        private static void AddJumpComponent(ref EcsEntity entity)
        {
            ref var jump = ref entity.Get<Jump>();

            jump.StartPosition = entity.Get<Movable>().Position;
            jump.Progress = 0f;
        }
    }
}