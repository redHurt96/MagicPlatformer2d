using System;
using RH.Game.InputTracking;

namespace RH.Game.Spells
{
    public abstract partial class BaseSpell
    {
        protected abstract class BaseSpellTracker
        {
            public event Action DrawComplete;
            
            public void Init()
            {
                PlayerInput.Pressed += StartTrack;
                PlayerInput.Released += FinishTrack;
            }

            public void Dispose()
            {
                PlayerInput.Pressed -= StartTrack;
                PlayerInput.Released -= FinishTrack;
            }

            protected abstract void StartTrack();
            protected abstract void FinishTrack();

            protected void InvokeComplete() => DrawComplete?.Invoke();
        }
    }
}