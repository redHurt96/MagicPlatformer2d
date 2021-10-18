using Zenject;
using UnityEngine;
using RH.Game.Data;

namespace RH.Game.Infrastructure.DataInstallers
{
    [CreateAssetMenu(fileName = "New PlayerData", menuName = "Game/PlayerData", order = 0)]
    public class PlayerDataInstaller : ScriptableObjectInstaller
    {
        [SerializeField] private PlayerData _playerData;

        public override void InstallBindings()
        {
            Container.BindInstance(_playerData);
        }
    }
}