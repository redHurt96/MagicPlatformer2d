using UnityEngine;
using Between.Interfaces;
using Between.Teams;

namespace Between.Damage
{
    public abstract class BaseDamagableObject : MonoBehaviour, IDamagable
    {
        public abstract Team Team { get; }
        public float Health { get; protected set; }

        [SerializeField] private Protection[] _protections;
        [SerializeField] private float MaxHealth;

        public void ApplyDamage(DamageItem damage)
        {
            if (Health <= 0) 
                return;

            HitProtection(damage.Type, ref damage.Value);
            HitHealth(damage.Value);
            PerformAfterHit();
        }

        private void PerformAfterHit()
        {
            if (Health > 0)
                PerformOnDamage();
            else
                PerformOnDie();
        }

        protected abstract void PerformOnDie();
        protected abstract void PerformOnDamage();

        private void HitProtection(DamageType type, ref float damage)
        {
            if (_protections == null || _protections.Length == 0)
                return;

            foreach (var protection in _protections)
            {
                if (protection.DamageType == type && protection.Value > 0)
                {
                    protection.Value -= damage;
                    damage = protection.Value < 0 ? -protection.Value : 0f;
                }
            }
        }

        private void HitHealth(float damage)
        {
            Health = Mathf.Max(Health - damage, 0f);
        }
    }
}