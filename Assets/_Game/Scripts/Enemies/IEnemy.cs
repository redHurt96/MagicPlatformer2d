using UnityEngine;
using Between.Damage;
using Between.Teams;

namespace RH.Game.Enemies
{
    public abstract class BaseEnemy : MonoBehaviour, IDamagable
    {
        public Team Team => Team.Enemies;

        public abstract void ApplyDamage(DamageItem damage);
    }
}
