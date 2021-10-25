using Between.Damage;
using Between.Interfaces;
using Between.Teams;
using UnityEngine;

namespace RH.Game.Enemies
{
    [RequireComponent(typeof(CapsuleCollider2D), typeof(Rigidbody2D))]
    public class Dummy : MonoBehaviour, IDamagable
    {
        public Team Team => _team;

        private Team _team = Team.Enemies;

        public void ApplyDamage(DamageItem damage)
        {
            Destroy(gameObject);
        }
    }
}