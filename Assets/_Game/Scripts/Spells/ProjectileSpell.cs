using System.Collections.Generic;
using RH.Game.Infrastructure;
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
            Vector3 direction = default;

            switch (GameSettings.Instance.CastType)
            {
                case SpellsCollection.CastType.SpellsBar:
                    direction = (points[^1] - points[0]).normalized;
                    break;
                case SpellsCollection.CastType.CastIfCan:
                    direction = (points[^1] - Level.Player.position).normalized;
                    break;
                default:
                    break;
            }
            
            _spawner.Spawn(points[0], direction);
        }
    }
}