namespace RH.Game.Spells
{
    public abstract partial class BaseSpell
    {
        public class EmptyBehavior : CompleteBehavior
        {
            public override bool IsComplete { get; protected set; } = true;

            public override void Apply()
            {
                //
            }
        }
    }
}