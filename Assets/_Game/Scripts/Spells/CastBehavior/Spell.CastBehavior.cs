using System.Collections.Generic;
using UnityEngine;

namespace RH.Game.Spells
{
    public partial class Spell
    {
        public abstract class CastBehavior
        {
            public abstract void Cast(List<Vector3> points);
        }
    }
}
