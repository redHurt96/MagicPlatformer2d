using Between.Damage;
using UnityEngine;

namespace RH.Game.Enemies
{
    [RequireComponent(typeof(CapsuleCollider2D), typeof(Rigidbody2D))]
    public class Dummy : BaseEnemy
    {
        public override void ApplyDamage(DamageItem damage)
        {
            Destroy(gameObject);
        }
    }
}