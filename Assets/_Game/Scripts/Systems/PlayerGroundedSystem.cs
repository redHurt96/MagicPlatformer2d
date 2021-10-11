using Leopotam.Ecs;
using RH.Game.Components;
using RH.Game.Services;

namespace RH.Game.Systems
{
    public sealed class PlayerGroundedSystem : IEcsRunSystem
    {
        private readonly StaticData _staticData;
        private EcsFilter<Movable> _filter;

        public void Run()
        {
            foreach (int i in _filter)
            {
                ref var movable = ref _filter.Get1(i);
                ref var entity = ref _filter.GetEntity(i);

                if (CanAddGrounded(ref movable, ref entity))
                    AddGroundedComponent(ref entity);
                else if (CanRemoveGrounded(ref movable, ref entity))
                    entity.Del<Grounded>();
            }

            bool CanAddGrounded(ref Movable movable, ref EcsEntity entity) => !entity.Has<Grounded>() && movable.GroundDetector.IsGrounded;
            bool CanRemoveGrounded(ref Movable movable, ref EcsEntity entity) => entity.Has<Grounded>() && !movable.GroundDetector.IsGrounded;
        }

        private void AddGroundedComponent(ref EcsEntity entity)
        {
            entity.Get<Grounded>();

            if (entity.Has<Jump>())
            {
                ref var jump = ref entity.Get<Jump>();

                if (jump.Progress > _staticData.JumpTreshhold)
                            entity.Del<Jump>();
            }
        }
    }
}