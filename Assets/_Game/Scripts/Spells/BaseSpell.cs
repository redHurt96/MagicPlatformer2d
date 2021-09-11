namespace RH.Game.Spells
{
    public abstract partial class BaseSpell
    {
        protected abstract BaseSpellTracker tracker { get; }
        
        
        public void Init()
        {
            tracker.DrawComplete += PerformOnDrawComplete;
            tracker.Init();
        }

        public void Dispose()
        {
            tracker.DrawComplete -= PerformOnDrawComplete;
            tracker.Dispose();
        }

        protected abstract void PerformOnDrawComplete();

        protected abstract class CompleteBehavior
        {
            
        }
    }
}
