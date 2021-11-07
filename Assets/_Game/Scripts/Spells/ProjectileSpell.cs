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
            Vector3 startPoint = default;
            Vector3 direction = default;

            switch (GameSettings.Instance.CastType)
            {
                case SpellsCollection.CastType.SpellsBar:
                    startPoint = points[0];
                    direction = (points[^1] - points[0]).normalized;
                    break;
                case SpellsCollection.CastType.CastIfCan:
                    startPoint = CalculateCastPoint(points);
                    direction = (points[^1] - startPoint).normalized;
                    break;
                default:
                    break;
            }
            
            _spawner.Spawn(startPoint, direction);

            Vector3 CalculateCastPoint(List<Vector3> points) =>
                Vector3.Lerp(Level.Player.position, points[0], GameSettings.Instance.ProjectileCastDistanceFromPlayer / (points[^1] - Level.Player.position).magnitude);
        }
    }
}