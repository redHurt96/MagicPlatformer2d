using System;

namespace RH.Game.Spells
{
    public partial class Spell
    {
        public abstract class CompleteBehavior
        {
            public abstract bool IsComplete { get; protected set; }
            
            public abstract void Apply();
        }
    }
}