using System.Collections.Generic;
using UnityEngine;

namespace RH.Game.Spells
{
    public partial class Spell
    {
        public class EnoughDragCondition : CastCondition
        {
            private readonly float _lenght;

            public EnoughDragCondition(float lenght)
            {
                this._lenght = lenght;
            }

            public override bool CanCast(List<Vector3> points)
            {
                return (points[^1] - points[0]).sqrMagnitude > Mathf.Pow(_lenght, 2);
            }
        }
    }
}