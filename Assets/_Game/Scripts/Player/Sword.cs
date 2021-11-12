using Between.Damage;
using Between.Interfaces;
using UnityEngine;

namespace RH.Game.Player
{
    [RequireComponent(typeof(Collider2D))]
    public class Sword : MonoBehaviour
    {
        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.isTrigger)
                return;

            if (other.TryGetComponent<IDamagable>(out var damagable))
                damagable.ApplyDamage(new DamageItem(DamageType.Sword, 1));
        }
    }
}