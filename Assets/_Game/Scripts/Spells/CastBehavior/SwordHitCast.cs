using RH.Game.Player;
using System.Collections.Generic;
using UnityEngine;

namespace RH.Game.Spells
{
    public partial class Spell
    {
        public class SwordHitCast : CastBehavior
        {
            public SwordHitCast()
            {
                SwordAnchor.Instance.CreateSword();
            }

            public override void Cast(List<Vector3> points) =>
                SwordHit.Instance.Execute();
        }
    }
}
