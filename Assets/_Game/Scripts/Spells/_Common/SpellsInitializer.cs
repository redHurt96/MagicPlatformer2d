using System.Collections.Generic;
using UnityEngine;

namespace RH.Game.Spells
{
    public class SpellsInitializer : MonoBehaviour
    {
        private InputTracker _inputTracker;
        
        private void Start()
        {
            InitSpells();
            
            _inputTracker = new InputTracker();
            _inputTracker.Init();
            _inputTracker.DrawComplete += CastSpell;
        }

        private void InitSpells()
        {
            var spells = new SpellsCollection();
            spells.AddSpell(SpellType.Projectile, new ProjectileSpell(new BaseSpell.HasDragCondition(), new BaseSpell.EmptyBehavior()));
            spells.AddSpell(SpellType.Shield, new ShieldSpell(new BaseSpell.HasDragCondition(), new BaseSpell.EmptyBehavior()));
        }

        private void CastSpell(List<Vector3> points)
        {
            SpellsCollection.Instance.CastSpell(points);
        }

        private void OnDestroy()
        {
            _inputTracker.DrawComplete -= CastSpell;
            _inputTracker.Dispose();
            _inputTracker = null;
            SpellsCollection.DestroyInstance();
        }
    }
}
