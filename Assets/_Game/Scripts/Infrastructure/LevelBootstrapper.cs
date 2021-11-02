using RH.Game.Settings;
using UnityEngine;

namespace RH.Game.Infrastructure
{
    public class LevelBootstrapper : MonoBehaviour
    {
        [SerializeField] private GameSettings _settings;
        [SerializeField] private Transform _canvas;

        private Level _level;

        private void Awake()
        {
            _level = new Level(_settings);
            FpsIncreaser.Perform();
            CreateMoveUi();
        }

        private void OnDestroy()
        {
            _level.Dispose();
        }

        private void CreateMoveUi() => new InputUiCreator(_canvas).Execute(_settings.MoveUiType);
    }
}