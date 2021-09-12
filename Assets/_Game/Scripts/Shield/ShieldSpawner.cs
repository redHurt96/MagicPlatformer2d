using System.Collections.Generic;
using UnityEngine;

namespace Between.SpellsEffects.ShieldSpell
{
    public class ShieldSpawner
    {
        private Shield _prefab;

        private float _shieldSize => _prefab.Size;

        public ShieldSpawner(Shield prefab)
        {
            _prefab = prefab;
        }

        public void Spawn(Vector3 from, Vector3 to)
        {
            var shieldsSpawnPoints = CalculateShieldPositions(new List<Vector3> { from, to });
            SpawnShields(shieldsSpawnPoints);
        }

        public void Spawn(List<Vector3> curve)
        {
            var shieldsSpawnPoints = CalculateShieldPositions(curve);
            SpawnShields(shieldsSpawnPoints);
        }

        private void SpawnShields(List<Vector3> shieldsSpawnPoints)
        {
            foreach (var point in shieldsSpawnPoints)
                SpawnSingleShield(point);
        }

        private List<Vector3> CalculateShieldPositions(List<Vector3> points)
        {
            List<Vector3> shieldPoints = new List<Vector3>() { points[0] };

            for (int i = 0; i < points.Count; i++)
            {
                Vector3 lastShieldPoint = shieldPoints[shieldPoints.Count - 1];
                float distance = Vector3.Distance(points[i], lastShieldPoint);

                if (distance > _shieldSize)
                {
                    Vector3 shieldPoint = Vector3.Lerp(lastShieldPoint, points[i], _shieldSize / distance);
                    shieldPoints.Add(shieldPoint);

                    i--;
                }
            }

            return shieldPoints;
        }
        
        private void SpawnSingleShield(Vector3 point)
        {
            Object.Instantiate(_prefab, point, Quaternion.identity);
        }
    }
}