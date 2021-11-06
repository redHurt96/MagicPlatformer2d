using UnityEngine;
using UnityEngine.UI;
using RH.Game.Infrastructure;
using RH.Game.Settings;
using RH.Utilities.UI;

namespace RH.Game.InputUiSelecting
{
    public class InputUiSelector : BaseActionButton
    {
        [SerializeField] private InputUiCreator.InputType _type;
        [SerializeField] private GameSettings _gameSettings;

        protected override void PerformOnClick()
        {
            _gameSettings.MoveUiType = _type;
        }

        private void Update()
        {
            _button.interactable = _gameSettings.MoveUiType != _type;
        }
    }
}