using System.Collections.Generic;
using UnityEngine;

namespace RH.Game.Spells
{
    public partial class Spell
    {
        public class ProjectileFromDraw : ProjectileCastBehavior
        {
            public override void Cast(List<Vector3> points) => 
                _spawner.Spawn(points[0], (points[^1] - points[0]).normalized);
        }
    }
}
