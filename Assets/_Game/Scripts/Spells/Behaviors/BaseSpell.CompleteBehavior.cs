using System;

namespace RH.Game.Spells
{
    public abstract partial class BaseSpell
    {
        public abstract class CompleteBehavior
        {
            public bool IsComplete { get; protected set; }
            
            public abstract void Apply();
        }
    }
}