using System.Collections.Generic;
using UnityEngine;

namespace RH.Game.Spells
{
    public partial class Spell
    {
        public class AlwaysTrueCondition : CastCondition
        {
            public override bool CanCast(List<Vector3> points) => true;
        }
    }
}