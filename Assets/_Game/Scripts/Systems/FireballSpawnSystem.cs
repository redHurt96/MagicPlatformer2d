using Leopotam.Ecs;
using RH.Game.Components;
using RH.Game.Enums;
using RH.Game.Services;
using UnityEngine;

namespace RH.Game.Systems
{
    public class FireballSpawnSystem : IEcsRunSystem
    {
        private readonly SpellType _spellType;
        private readonly StaticData _staticData;
        
        private EcsFilter<CurrentSpell> _spellFilter;
        private EcsFilter<TouchInput, FinishInput> _touchFilter;
        
        public void Run()
        {
            foreach (int i in _spellFilter)
            {
                ref var currentSpell = ref _spellFilter.Get1(i);
                
                if (currentSpell.Type != _spellType)
                    break;

                foreach (int j in _touchFilter)
                {
                    ref var touchInput = ref _touchFilter.Get1(j);
                    Spawn(touchInput.Points[0], touchInput.Points[^1]);
                    RemoveInputEntity(j);
                }
            }
        }

        private void Spawn(Vector2 from, Vector2 to)
        {
            
        }

        private void RemoveInputEntity(int j)
        {
            ref var entity = ref _touchFilter.GetEntity(j);
            entity.Destroy();
        }
    }
}
