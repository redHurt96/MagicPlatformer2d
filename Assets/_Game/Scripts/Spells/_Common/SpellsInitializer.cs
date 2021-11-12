using RH.Utilities.SingletonAccess;
using System.Collections.Generic;
using UnityEngine;

namespace RH.Game.Spells
{
    public class SpellsInitializer : Singleton<SpellsInitializer>
    {
        private InputTracker _inputTracker;
        private CastType _castType;
        private SpellsCollection _spellsCollection;

        public void Init(CastType castType)
        {
            _castType = castType;

            SetSpells();
            InitTracker();
        }

        public void ChangeCastType()
        {
            _castType = _castType == CastType.ProjectileByDraw ? CastType.ProjectileByTap : CastType.ProjectileByDraw;
            SetSpells();
        }

        protected override void PrepareToDestroy()
        {
            DisposeTracker();
            _spellsCollection = null;
        }
        
        private void SetSpells()
        {
            _spellsCollection = new SpellsCollection();

            switch (_castType)
            {
                case CastType.ProjectileByDraw:
                    _spellsCollection.AddSpell(SpellType.Projectile, SpellBuilder.ProjectileDrawSpell());
                    break;
                case CastType.ProjectileByTap:
                    _spellsCollection.AddSpell(SpellType.Projectile, SpellBuilder.ProjectileTapSpell());
                    _spellsCollection.AddSpell(SpellType.Shield, SpellBuilder.ShieldSpell());
                    break;
                case CastType.ProjectileShieldAndSword:
                    _spellsCollection.AddSpell(SpellType.Projectile, SpellBuilder.ProjectileArrowSpell());
                    _spellsCollection.AddSpell(SpellType.Shield, SpellBuilder.ShieldByLine());
                    _spellsCollection.AddSpell(SpellType.Sword, SpellBuilder.SwordHit());
                    break;
                default:
                    break;
            }
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

        private void CastSpell(List<Vector3> points) => 
            _spellsCollection?.CastSpell(points);
    }
}