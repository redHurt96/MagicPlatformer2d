using System.Collections.Generic;
using UnityEngine;

namespace RH.Game.Spells
{
    public abstract partial class BaseSpell
    {
        protected readonly CastCondition castCondition;
        protected readonly CompleteBehavior completeBehavior;

        public BaseSpell(CastCondition condition, CompleteBehavior behavior)
        {
            castCondition = condition;
            completeBehavior = behavior;
        }

        public void TryCast(List<Vector3> points)
        {
            if (!CanCast(points))
                return;
            
            Cast(points);
            completeBehavior.Apply();
        }

        protected abstract void Cast(List<Vector3> points);
        
        private bool CanCast(List<Vector3> points) => castCondition.CanCast(points) && completeBehavior.IsComplete;
    }
}
