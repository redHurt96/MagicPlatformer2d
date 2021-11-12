using System.Collections.Generic;
using UnityEngine;

namespace RH.Game.Spells
{
    public partial class Spell
    {
        public class ProjectileByArrow : ProjectileCastBehavior
        {
            public override void Cast(List<Vector3> points)
            {
                var startPoint = Vector3.Lerp(points[0], points[^1], .5f);
                var directionPoint = points[points.Count / 2];

                _spawner.Spawn(startPoint, (directionPoint - startPoint).normalized);
            }
        }
    }
}
