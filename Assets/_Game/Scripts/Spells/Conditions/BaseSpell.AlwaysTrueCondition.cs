using System.Collections.Generic;
using UnityEngine;

namespace RH.Game.Spells
{
    public abstract partial class BaseSpell
    {
        public class AlwaysTrueCondition : CastCondition
        {
            public override bool CanCast(List<Vector3> points) => true;
        }
    }
}