namespace RH.Game.Spells
{
    public abstract partial class BaseSpell
    {
        public abstract class CastCondition
        {
            public abstract bool CanCast { get; }
        }
    }
}