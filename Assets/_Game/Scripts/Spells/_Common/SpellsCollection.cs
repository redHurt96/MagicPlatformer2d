using System;
using System.Collections.Generic;
using UnityEngine;

namespace RH.Game.Spells
{
    public class SpellsCollection
    {
        private List<Spell> _spells = new List<Spell>();

        public void AddSpell(SpellType type, Spell spell)
        {
            if (_spells.Contains(spell))
                throw new ArgumentException($"Spell with type {type} already added to dictionary");

            _spells.Add(spell);
        }
        
        public void CastSpell(List<Vector3> drawPoints)
        {
            foreach (Spell spell in _spells)
            {
                if (spell.TryCast(drawPoints))
                    break;
            }
        }
    }
}