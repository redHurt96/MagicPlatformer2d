using System;
using System.Collections.Generic;
using UnityEngine;
using RH.Utilities.SingletonAccess;

namespace RH.Game.Spells
{
    public class SpellsCollection : Singleton<SpellsCollection>
    {
        public SpellType CurrentSpellType { get; private set; }

        private Dictionary<SpellType, BaseSpell> _spells = new Dictionary<SpellType, BaseSpell>();

        private BaseSpell _currentSpell => _spells[CurrentSpellType];
        
        public void AddSpell(SpellType type, BaseSpell spell)
        {
            if (_spells.ContainsKey(type))
                throw new ArgumentException($"Spell with type {type} already added to dictionary");
            
            _spells.Add(type, spell);
        }
        
        public void SelectSpell(SpellType type)
        {
            CurrentSpellType = type;
        }

        public void CastSpell(List<Vector3> drawPoints)
        {
            _currentSpell.TryCast(drawPoints);
        }
    }
}