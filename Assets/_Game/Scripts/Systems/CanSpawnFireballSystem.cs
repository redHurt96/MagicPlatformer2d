using UnityEngine;
using Between;
using Leopotam.Ecs;
using RH.Game.Components;
using RH.Game.Enums;
using RH.Game.Services;

namespace RH.Game.Systems
{
    public class CanSpawnFireballSystem : IEcsRunSystem
    {
        private readonly StaticData _staticData;

        private EcsFilter<TouchInput, FinishInput> _inputFilter;
        private EcsFilter<CurrentSpell> _spellFilter;

        public void Run()
        {
            foreach (int i in _spellFilter)
            {
                ref var spell = ref _spellFilter.Get1(i);

                if (spell.Type != SpellType.Fireball)
                    continue;

                foreach (int j in _inputFilter)
                {
                    ref var touchInput = ref _inputFilter.Get1(j);

                    if (IsValidLenght(ref touchInput))
                        _inputFilter.GetEntity(j).Get<CanSpawnFireball>();
                }
            }
        }

        private bool IsValidLenght(ref TouchInput touchInput)
        {
            Vector2 start = Convert(touchInput.Points[0]);
            Vector2 end = Convert(touchInput.Points[^1]);

            return Vector2.Distance(start, end) >= _staticData.FireballCastInputLenghtTreshhold;

            Vector3 Convert(Vector2 point) => GameCamera.ScreenToWorldPoint(point);
        }
    }
}