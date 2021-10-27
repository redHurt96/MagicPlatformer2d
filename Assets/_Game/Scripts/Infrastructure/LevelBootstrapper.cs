using RH.Game.Settings;
using UnityEngine;

namespace RH.Game.Infrastructure
{
    public class LevelBootstrapper : MonoBehaviour
    {
        [SerializeField] private GameSettings _settings;

        private Level _level;

        private void Awake()
        {
            _level = new Level(_settings);
        }

        private void OnDestroy()
        {
            _level.Dispose();
        }
    }
}