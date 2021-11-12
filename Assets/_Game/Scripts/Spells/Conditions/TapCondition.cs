using System.Collections.Generic;
using UnityEngine;

namespace RH.Game.Spells
{
    public partial class Spell
    {
        public class TapCondition : CastCondition
        {
            public override bool CanCast(List<Vector3> points) => points.Count == 2;
        }
    }
}