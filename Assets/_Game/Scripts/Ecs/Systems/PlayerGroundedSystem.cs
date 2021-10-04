using Leopotam.Ecs;
using RH.Game.Components;

namespace RH.Game.Systems 
{
    sealed class PlayerGroundedSystem : IEcsRunSystem 
    {
        private EcsFilter<Player> _playerFilter;

        void IEcsRunSystem.Run () 
        {
            foreach (var i in _playerFilter)
            {
                ref var player = ref _playerFilter.Get1(i);
                ref var playerEntity = ref _playerFilter.GetEntity(i);

                UpdatePlayerData(ref player, ref playerEntity);
            }
        }

        private void UpdatePlayerData(ref Player player, ref EcsEntity playerEntity)
        {
            if (IsGrounded(ref player))
            {
                playerEntity.Get<Grounded>();

                if (playerEntity.Has<Jump>())
                    playerEntity.Del<Jump>();
            }
            else
            {
                playerEntity.Del<Grounded>();
            }
        }

        private bool IsGrounded(ref Player player) => player.GroundDetector.IsGrounded;
    }
}