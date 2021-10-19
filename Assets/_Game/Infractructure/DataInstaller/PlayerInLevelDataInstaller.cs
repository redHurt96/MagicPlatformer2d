using RH.Game.Data;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace RH.Game.Infrastructure.DataInstaller
{
    public class PlayerInLevelDataInstaller : ScriptableObjectInstaller
    {
        [SerializeField] private PlayerInLevelData _playerInLevelData;

        public override void InstallBindings()
        {
            Container.BindInstance(_playerInLevelData);
        }
    }
}