using RH.Game.Infrastructure;
using RH.Game.Settings;
using System.Collections.Generic;
using UnityEngine;

namespace RH.Game.Spells
{
    public partial class Spell
    {
        public class ProjectileFromHero : ProjectileCastBehavior
        {
            public override void Cast(List<Vector3> points)
            {
                var startPoint = CalculateCastPoint(points);
                var direction = (points[^1] - startPoint).normalized;

                Vector3 CalculateCastPoint(List<Vector3> points) =>
                    Vector3.Lerp(Level.Player.position, points[0], GameSettings.Instance.ProjectileCastDistanceFromPlayer / (points[^1] - Level.Player.position).magnitude);

                _spawner.Spawn(startPoint, direction);
            }
        }
    }
}
