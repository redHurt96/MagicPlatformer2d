using System.Collections.Generic;
using UnityEngine;

namespace RH.Game.Spells
{
    public partial class Spell
    {
        protected readonly CastCondition _castCondition;
        protected readonly CastBehavior _castBehavior;
        protected readonly CompleteBehavior _completeBehavior;

        public Spell(CastCondition castCondition, CastBehavior castBehavior, CompleteBehavior completeBehavior)
        {
            _castCondition = castCondition;
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

        private bool CanCast(List<Vector3> points) => _castCondition.CanCast(points) && _completeBehavior.IsComplete;
    }
}
