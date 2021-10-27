using RH.Game.Settings;
using System.Collections.Generic;
using UnityEngine;

namespace RH.Game.Spells
{
    public class SpellsInitializer
    {
        private InputTracker _inputTracker;
        
        public void Init()
        {
            InitSpells();
            InitTracker();
        }

        public void Dispose()
        {
            DisposeTracker();
            SpellsCollection.DestroyInstance();
        }

        private void InitTracker()
        {
            _inputTracker = new InputTracker();
            _inputTracker.Init();
            _inputTracker.DrawComplete += CastSpell;
        }

        private void DisposeTracker()
        {
            _inputTracker.DrawComplete -= CastSpell;
            _inputTracker.Dispose();
            _inputTracker = null;
        }

        private void InitSpells()
        {
            var spells = new SpellsCollection();
            
            spells.AddSpell(
                SpellType.Projectile, 
                new ProjectileSpell(new BaseSpell.EnoughDragCondition(GameSettings.Instance.ProjectileInputLenght), 
                new BaseSpell.EmptyBehavior()));

            spells.AddSpell(
                SpellType.Shield, 
                new ShieldSpell(new BaseSpell.EnoughDragCondition(GameSettings.Instance.ShieldInputLenght), 
                new BaseSpell.EmptyBehavior()));
        }

        private void CastSpell(List<Vector3> points)
        {
            SpellsCollection.Instance.CastSpell(points);
        }
    }
}
