using RH.Game.Player;
using Sirenix.OdinInspector;
using UnityEngine;
using Zenject;

namespace RH.Game.Infrastructure
{
    public class PlayerInstaller : MonoInstaller
    {
        [SerializeField, AssetsOnly] private GameObject _playerPrefab;
        [SerializeField, SceneObjectsOnly] private Transform _startPoint;

        public override void InstallBindings()
        {
            GameObject player = CreatePlayer();

            BindComponent<Mover>(player);
            BindComponent<Jumper>(player);
        }

        private GameObject CreatePlayer()
        {
            return Container
                .InstantiatePrefab(_playerPrefab, _startPoint.position, Quaternion.identity, null);
        }

        private void BindComponent<T>(GameObject from)
        {
            Container
                .Bind<T>()
                .FromInstance(from.GetComponent<T>())
                .AsSingle();
        }
    }
}