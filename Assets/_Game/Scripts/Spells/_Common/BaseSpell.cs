using System.Collections.Generic;
using UnityEngine;

namespace RH.Game.Spells
{
    public abstract partial class BaseSpell
    {
        protected readonly CastCondition castCondition;
        protected readonly CompleteBehavior completeBehavior;

        private bool _canCast => castCondition.CanCast && completeBehavior.IsComplete;

        public BaseSpell(CastCondition condition, CompleteBehavior behavior)
        {
            castCondition = condition;
            completeBehavior = behavior;
        }
        
        public void TryCast(List<Vector3> points)
        {
            if (!_canCast)
                return;
            
            Cast(points);
            completeBehavior.Apply();
        }

        protected abstract void Cast(List<Vector3> points);
    }
}
