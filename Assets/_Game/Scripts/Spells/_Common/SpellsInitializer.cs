using System.Collections.Generic;
using UnityEngine;

namespace RH.Game.Spells
{
    public class SpellsInitializer : MonoBehaviour
    {
        private InputTracker _inputTracker;
        
        private void Awake()
        {
            new SpellsCollection();
            _inputTracker = new InputTracker();
            _inputTracker.DrawComplete += CastSpell;
        }

        private void CastSpell(List<Vector3> points)
        {
            SpellsCollection.Instance.CastSpell(points);
        }

        private void OnDestroy()
        {
            _inputTracker.DrawComplete += CastSpell;
            SpellsCollection.DestroyInstance();
            _inputTracker = null;
        }
    }
}
