using Leopotam.Ecs;
using RH.Game.Components;
using UnityEngine;

namespace RH.Game.Systems
{
    public class DestroySpellPainterSystem : IEcsRunSystem
    {
        private EcsFilter<SpellPainter, FinishInput> _filter;

        public void Run()
        {
            foreach (int i in _filter)
            {
                GameObject.Destroy(_filter.Get1(i).Transform.gameObject);
                _filter.GetEntity(i).Del<SpellPainter>();
            }
        }
    }
}