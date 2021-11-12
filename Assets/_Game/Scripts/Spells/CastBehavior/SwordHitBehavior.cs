using RH.Game.Player;
using System.Collections.Generic;
using UnityEngine;

namespace RH.Game.Spells
{
    public partial class Spell
    {
        public class SwordHitBehavior : CastBehavior
        {
            public override void Cast(List<Vector3> points) => 
                SwordHit.Instance.Execute();
        }
    }
}
