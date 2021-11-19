using System;
using System.Collections;
using UnityEngine;
using RH.Utilities.SingletonAccess;
using RH.Utilities.Coroutines;
using RH.Game.Settings;

namespace RH.Game.ManaManagement
{
    public class Mana : Singleton<Mana>
    {
        public event Action ValueChanged;

        public float Value
        {
            get => _value;
            private set
            {
                if (!Mathf.Approximately(value, _value))
                    ValueChanged?.Invoke();

                _value = Mathf.Clamp(value, 0f, MaxValue);
            }
        }

        public readonly float MaxValue;

        private float _value;
        private float _manaRecoveryPerSec => GameSettings.Instance.ManaRecoveryPerSecond;

        public Mana(float maxValue)
        {
            Value = MaxValue = maxValue;
            CoroutineLauncher.Start(Recovery());
        }

        public void Spend(float manaCost) =>
            Value = Mathf.Max(Value - manaCost, 0f);

        public bool CanSpend(float manaCost) => 
            manaCost <= Value;

        protected override void PrepareToDestroy() =>
            CoroutineLauncher.Stop(Recovery());

        private IEnumerator Recovery()
        {
            while (Application.isPlaying)
            {
                if (Value < MaxValue)
                    Value += _manaRecoveryPerSec * Time.deltaTime;

                yield return null;
            }
        }
    }
}