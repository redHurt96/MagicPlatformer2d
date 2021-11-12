using System.Collections.Generic;
using UnityEngine;
using RH.Game.Settings;

namespace RH.Game.Spells
{
    public partial class Spell
    {
        public class DrawLineCondition : CastCondition
        {
            public override bool CanCast(List<Vector3> points)
            {
                var middlePoint = points[points.Count / 2];
                var angle = Vector3.Angle(points[^1] - points[0], middlePoint - points[0]);

                return angle < GameSettings.Instance.LineAngleTreshhold;
            }
        }

        public class DrawArrowCondition : CastCondition
        {
            public override bool CanCast(List<Vector3> points)
            {
                var middlePoint = points[points.Count / 2];
                var angle = Vector3.Angle(points[^1] - points[0], middlePoint - points[0]);

                return angle > GameSettings.Instance.LineAngleTreshhold;
            }
        }
    }
}