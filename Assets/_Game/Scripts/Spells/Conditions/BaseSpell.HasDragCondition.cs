using System.Collections.Generic;
using UnityEngine;

namespace RH.Game.Spells
{
    public partial class Spell
    {
        public class HasDragCondition : CastCondition
        {
            public override bool CanCast(List<Vector3> points)
            {
                return points[0] != points[^1];
            }
        }
    }
}