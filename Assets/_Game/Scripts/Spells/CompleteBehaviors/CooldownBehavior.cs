using RH.Utilities.Coroutines;
using System.Collections;
using UnityEngine;

namespace RH.Game.Spells
{
    public partial class Spell
    {
        public class CooldownBehavior : CompleteBehavior
        {
            private readonly float _time;

            public override bool IsComplete { get; protected set; } = true;

            public CooldownBehavior(float time)
            {
                _time = time;
            }

            public override void Apply() => 
                CoroutineLauncher.Start(Cooldown());

            private IEnumerator Cooldown()
            {
                IsComplete = false;

                yield return new WaitForSeconds(_time);
                
                IsComplete = true;
            }
        }
    }
}