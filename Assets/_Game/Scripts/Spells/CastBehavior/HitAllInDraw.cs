using Between.Damage;
using RH.Game.Enemies;
using System.Collections.Generic;
using UnityEngine;

namespace RH.Game.Spells
{
    public partial class Spell
    {
        public class HitAllInDraw : CastBehavior
        {
            public override void Cast(List<Vector3> points)
            {
                List<BaseEnemy> enemies = EnemiesFinder.Find(points);

                foreach (BaseEnemy enemy in enemies)
                    enemy.ApplyDamage(new DamageItem(DamageType.DeathLine, 1f));
            }
        }
    }
}
