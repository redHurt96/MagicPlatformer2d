using System.Collections.Generic;
using UnityEngine;

namespace RH.Game.Spells
{
    public partial class Spell
    {
        protected readonly List<CastCondition> _castConditions;
        protected readonly CastBehavior _castBehavior;
        protected readonly CompleteBehavior _completeBehavior;

        public Spell(CastCondition castCondition, CastBehavior castBehavior, CompleteBehavior completeBehavior) : 
            this(new List<CastCondition> { castCondition }, castBehavior, completeBehavior)
        {
        }

        public Spell(List<CastCondition> castConditions, CastBehavior castBehavior, CompleteBehavior completeBehavior)
        {
            _castConditions = castConditions;
            _castBehavior = castBehavior;
            _completeBehavior = completeBehavior;
        }

        public bool TryCast(List<Vector3> points)
        {
            if (!CanCast(points))
                return false;
            
            _castBehavior.Cast(points);
            _completeBehavior.Apply();

            return true;
        }

        private bool CanCast(List<Vector3> points)
        {
            foreach (CastCondition condition in _castConditions)
            {
                if (!condition.CanCast(points))
                    return false;
            }

            return _completeBehavior.IsComplete;
        }
    }
}
