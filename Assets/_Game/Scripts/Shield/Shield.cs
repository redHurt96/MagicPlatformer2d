using System.Collections;
using UnityEngine;
using Between.Damage;
using Between.Teams;
using RH.Game.Settings;

namespace Between.SpellsEffects.ShieldSpell
{
    public class Shield : MonoBehaviour, IDamagable
    {
        public Team Team { get; } = Team.Player;
        public float Size => transform.localScale.y;

        private float _lifeTime => GameSettings.Instance.ShieldLifeTime;

        private void Awake()
        {
            StartCoroutine(WaitToDestroy());
        }

        public void ApplyDamage(DamageItem damage)
        {
            DestroyShield();            
        }

        private IEnumerator WaitToDestroy()
        {
            yield return new WaitForSeconds(_lifeTime);

            if (this != null && gameObject != null)
                DestroyShield();
        }

        private void DestroyShield()
        {
            if (this == null)
                return;

            StopCoroutine(WaitToDestroy());
            Destroy(gameObject);
        }
    }
}