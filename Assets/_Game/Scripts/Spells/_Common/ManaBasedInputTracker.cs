using RH.Game.ManaManagement;
using RH.Game.Settings;

namespace RH.Game.Spells
{
    public class ManaBasedInputTracker : BaseInputTracker
    {
        private Mana _mana => Mana.Instance;
        private float _costPerUnit => GameSettings.Instance.ManaCostPerUnit;

        protected override void PerformOnTrack()
        {
            if (_drawPoints.Count < 2)
                return;

            var frameDistance = (_drawPoints[^1] - _drawPoints[^2]).magnitude;
            var manaCost = _costPerUnit * frameDistance;

            if (!_mana.CanSpend(manaCost))
                Break();
            else
                _mana.Spend(manaCost);
        }
    }
}