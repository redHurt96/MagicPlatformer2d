using System.Collections.Generic;
using Between.SpellsEffects.ShieldSpell;
using RH.Game.Settings;
using UnityEngine;

namespace RH.Game.Spells
{
    public class ShieldSpell : BaseSpell
    {
        private ShieldSpawner _spawner;

        public ShieldSpell(CastCondition condition, CompleteBehavior behavior) : base(condition, behavior)
        {
            _spawner = new ShieldSpawner(PrototypeSettings.Instance.ShieldPrefab);
        }

        protected override void Cast(List<Vector3> points)
        {
            points = СutByLenght(points);
            _spawner.Spawn(points);
        }

        private List<Vector3> СutByLenght(List<Vector3> points)
        {
            var cuttedPoints = new List<Vector3> { points[0] };
            float maxLenght = PrototypeSettings.Instance.ShieldsLenght;
            float currentLenght = 0f;

            for (int i = 1; i < points.Count; i++)
            {
                currentLenght += Vector3.Distance(points[i], points[i - 1]);
                cuttedPoints.Add(points[i]);

                if (currentLenght > maxLenght)
                    break;
            }

            return cuttedPoints;
        }
    }
}