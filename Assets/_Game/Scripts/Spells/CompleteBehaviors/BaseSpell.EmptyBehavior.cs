namespace RH.Game.Spells
{
    public partial class Spell
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