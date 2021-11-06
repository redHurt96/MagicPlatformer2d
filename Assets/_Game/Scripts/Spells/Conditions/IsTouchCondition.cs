using System.Collections.Generic;
using UnityEngine;

namespace RH.Game.Spells
{
    public abstract partial class BaseSpell
    {
        public class IsTouchCondition : CastCondition
        {
            public override bool CanCast(List<Vector3> points) => points.Count == 2;
        }
    }
}