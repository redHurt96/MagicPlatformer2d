using System.Collections.Generic;
using UnityEngine;

namespace RH.Game.Utilities
{
    public static class PointsPositionsCalculator
    {
        public static List<Vector3> CreateEquidistantPoints(List<Vector3> fromCurve, float pointSize)
        {
            List<Vector3> equidistantPoints = new List<Vector3>() { fromCurve[0] };

            for (int i = 0; i < fromCurve.Count; i++)
            {
                Vector3 lastShieldPoint = equidistantPoints[^1];
                float distance = Vector3.Distance(fromCurve[i], lastShieldPoint);

                if (distance > pointSize)
                {
                    Vector3 shieldPoint = Vector3.Lerp(lastShieldPoint, fromCurve[i], pointSize / distance);
                    equidistantPoints.Add(shieldPoint);

                    i--;
                }
            }

            return equidistantPoints;
        }
    }
}