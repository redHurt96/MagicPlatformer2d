using RH.Game.Settings;
using RH.Utilities.SingletonAccess;
using System.Collections.Generic;
using UnityEngine;

namespace RH.Game.Spells
{
    public class SpellsInitializer : Singleton<SpellsInitializer>
    {
        private IInputTracker _inputTracker;
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
                    AddSpell(SpellType.Projectile, SpellBuilder.ProjectileDrawSpell());
                    break;
                case CastType.ProjectileByTap:
                    AddSpell(SpellType.Projectile, SpellBuilder.ProjectileTapSpell());
                    AddSpell(SpellType.Shield, SpellBuilder.ShieldSpell());
                    break;
                case CastType.ProjectileShieldAndSword:
                    AddSpell(SpellType.Projectile, SpellBuilder.ProjectileArrowSpell());
                    AddSpell(SpellType.Shield, SpellBuilder.ShieldByLine());
                    AddSpell(SpellType.Sword, SpellBuilder.SwordHit());
                    break;
                case CastType.ShieldPushAndFireball:
                    AddSpell(SpellType.Projectile, SpellBuilder.ProjectileTapSpell());
                    AddSpell(SpellType.Push, SpellBuilder.Push());
                    AddSpell(SpellType.Shield, SpellBuilder.ShieldByLine());
                    break;
                case CastType.WithSeparateDeathLine:
                    AddSpell(SpellType.Push, SpellBuilder.Push());
                    AddSpell(SpellType.Projectile, SpellBuilder.DeathLine());
                    break;
                default:
                    break;
            }

            void AddSpell(SpellType type, Spell spell) => _spellsCollection.AddSpell(type, spell);
        }

        private void InitTracker()
        {
            _inputTracker = GameSettings.Instance.UseManaToDraw ? new ManaBasedInputTracker() : new InputTracker();
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