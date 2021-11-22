using RH.Game.Utilities;
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
            var shieldsSpawnPoints = CalculatePoints(new List<Vector3> { from, to });
            SpawnShields(shieldsSpawnPoints);
        }

        public void Spawn(List<Vector3> curve)
        {
            List<Vector3> shieldsSpawnPoints = CalculatePoints(curve);
            SpawnShields(shieldsSpawnPoints);
        }

        private void SpawnShields(List<Vector3> shieldsSpawnPoints)
        {
            foreach (var point in shieldsSpawnPoints)
                SpawnSingleShield(point);
        }

        private void SpawnSingleShield(Vector3 point) => 
            Object.Instantiate(_prefab, point, Quaternion.identity);

        private List<Vector3> CalculatePoints(List<Vector3> curve) => 
            PointsPositionsCalculator.CreateEquidistantPoints(curve, _shieldSize);
    }
}