using System.Collections.Generic;
using RH.Game.Projectiles;
using RH.Game.Settings;
using UnityEngine;

namespace RH.Game.Spells
{
    public class ProjectileSpell : BaseSpell
    {
        private ProjectileSpawner _spawner;
        
        public ProjectileSpell(CastCondition condition, CompleteBehavior behavior) : base(condition, behavior)
        {
            _spawner = new ProjectileSpawner(GameSettings.Instance.ProjectileData);
        }

        protected override void Cast(List<Vector3> points)
        {
            var direction = (points[^1] - points[0]).normalized;
            _spawner.Spawn(points[0], direction);
        }
    }
}