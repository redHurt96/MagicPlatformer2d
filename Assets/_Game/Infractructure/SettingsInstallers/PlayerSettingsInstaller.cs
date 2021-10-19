using Zenject;
using UnityEngine;
using RH.Game.Settings;

namespace RH.Game.Infrastructure.SettingsInstallers
{
    [CreateAssetMenu(fileName = "New PlayerData", menuName = "Game/PlayerData", order = 0)]
    public class PlayerSettingsInstaller : ScriptableObjectInstaller
    {
        [SerializeField] private PlayerSettings _playerData;

        public override void InstallBindings()
        {
            Container.BindInstance(_playerData);
        }
    }

    public class PlayerDataInstaller : ScriptableObjectInstaller
    {

    }
}