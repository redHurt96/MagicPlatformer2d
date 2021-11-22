using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using RH.Game.Utilities;

namespace RH.Game.Enemies
{
    public static class EnemiesFinder
    {
        private const float OVERLAP_RADIUS = 1f;

        public static List<BaseEnemy> Find(List<Vector3> where)
        {
            var enemies = new List<BaseEnemy>();
            List<Vector3> searchPoints = PointsPositionsCalculator.CreateEquidistantPoints(where, OVERLAP_RADIUS);

            foreach (Vector3 point in searchPoints)
                enemies.AddRange(FindEnemies(point));

            return enemies.Distinct().ToList();
        }

        private static List<BaseEnemy> FindEnemies(Vector3 where)
        {
            Collider2D[] colliders = Physics2D.OverlapCircleAll(where, OVERLAP_RADIUS);
            var enemies = new List<BaseEnemy>();

            foreach (Collider2D collider in colliders)
            {
                if (collider != null && collider.TryGetComponent<BaseEnemy>(out var enemy))
                {
                    if (!enemies.Contains(enemy))
                        enemies.Add(enemy);
                }
            }

            return enemies;
        }
    }
}