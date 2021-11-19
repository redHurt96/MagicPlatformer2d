using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace RH.Game.Enemies
{
    public static class EnemiesFinder
    {
        private const float OVERLAP_RADIUS = .1f;

        public static List<BaseEnemy> Find(List<Vector3> where)
        {
            var enemies = new List<BaseEnemy>();

            foreach (Vector3 point in where)
                enemies.AddRange(FindEnemies(point));

            CreateDebugSpheres(where);

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

        private static void CreateDebugSpheres(List<Vector3> where)
        {
            foreach (Vector3 point in where)
            {
                var sphere = GameObject.CreatePrimitive(PrimitiveType.Sphere).transform;

                sphere.localScale = Vector3.one * OVERLAP_RADIUS;
                sphere.position = point;

                Object.Destroy(sphere.gameObject, 3f);
            }
        }
    }
}