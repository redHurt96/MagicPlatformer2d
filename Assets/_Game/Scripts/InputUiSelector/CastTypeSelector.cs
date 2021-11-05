using UnityEngine;
using RH.Game.Settings;
using RH.Game.Spells;
using RH.Utilities.UI;

namespace RH.Game.UI
{
    public class CastTypeSelector : BaseActionButton
    {
        [SerializeField] private GameSettings _gameSettings;
        [SerializeField] private SpellsCollection.CastType _castType;

        protected override void PerformOnClick()
        {
            _gameSettings.CastType = _castType;
        }
    }
}