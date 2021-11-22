using RH.Game.Settings;
using RH.Game.Spells;
using RH.Utilities.UI;
using UnityEngine;

namespace RH.Game.InputUiSelecting
{
    public class SpellsSelector : BaseActionButton
    {
        [SerializeField] private CastType _type;
        [SerializeField] private GameSettings _gameSettings;

        protected override void PerformOnClick()
        {
            _gameSettings.DefaultCastType = _type;
        }

        private void Update()
        {
            _button.interactable = _gameSettings.DefaultCastType != _type;
        }
    }
}