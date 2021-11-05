using System.Collections.Generic;
using UnityEngine;
using RH.Game.Settings;

namespace RH.Game.Spells
{
    public class SpellsInitializer
    {
        private InputTracker _inputTracker;
        private SpellsBarCreator _spellsBarCreator;
        
        public void Init(Transform canvas)
        {
            SpellsCollection.CastType castType = GameSettings.Instance.CastType;

            InitSpells(castType);
            InitTracker();
            TryCreateBar(castType, canvas);
        }

        public void Dispose()
        {
            DisposeTracker();
            SpellsCollection.DestroyInstance();
            _spellsBarCreator?.Dispose();
        }

        private void InitTracker()
        {
            _inputTracker = new InputTracker();
            _inputTracker.Init();
            _inputTracker.DrawComplete += CastSpell;
        }

        private void TryCreateBar(SpellsCollection.CastType castType, Transform canvas)
        {
            if (castType != SpellsCollection.CastType.SpellsBar)
                return;

            _spellsBarCreator = new SpellsBarCreator(canvas);
            _spellsBarCreator.Execute();
        }

        private void DisposeTracker()
        {
            _inputTracker.DrawComplete -= CastSpell;
            _inputTracker.Dispose();
            _inputTracker = null;
        }

        private void InitSpells(SpellsCollection.CastType castType)
        {
            var spells = new SpellsCollection(castType);
            
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
