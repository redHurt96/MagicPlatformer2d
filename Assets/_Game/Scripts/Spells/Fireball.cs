using System.Collections.Generic;
using RH.Game.Projectiles;
using RH.Game.Settings;
using UnityEngine;

namespace RH.Game.Spells
{
    public class Fireball : BaseSpell
    {
        private ProjectileSpawner _spawner;
        
        public Fireball(CastCondition condition, CompleteBehavior behavior) : base(condition, behavior)
        {
            _spawner = new ProjectileSpawner(StaticData.Instance.ProjectileData);
        }

        protected override void Cast(List<Vector3> points)
        {
            var direction = (points[^1] - points[0]).normalized;
            _spawner.Spawn(points[0], direction);
        }
    }
}