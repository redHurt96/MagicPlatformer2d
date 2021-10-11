using Leopotam.Ecs;
using RH.Game.Components;

namespace RH.Game.Systems
{
    public class FireballDestroySystem : IEcsRunSystem
    {
        private EcsFilter<Fireball> _filter;

        public void Run()
        {
            foreach (int i in _filter)
            {

            }
        }
    }

    public class FireballMoveSystem : IEcsRunSystem
    {
        private EcsFilter<Fireball> _filter;

        public void Run()
        {
            foreach (int i in _filter)
                Move(ref _filter.Get1(i));
        }

        private void Move(ref Fireball fireball)
        {
            fireball.Rigidbody.MovePosition(fireball.Rigidbody.position + fireball.Direction * fireball.Speed);
        }
    }
}