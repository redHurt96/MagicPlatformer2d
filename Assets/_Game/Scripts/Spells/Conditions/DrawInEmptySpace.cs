using RH.Game.Enemies;
using System.Collections.Generic;
using UnityEngine;

namespace RH.Game.Spells
{
    public partial class Spell
    {
        public class DrawInEmptySpace : CastCondition
        {
            public override bool CanCast(List<Vector3> points) =>
                EnemiesFinder.Find(points).Count == 0;
        }
    }
}