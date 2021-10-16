using Between;
using Leopotam.Ecs;
using RH.Game.Components;
using RH.Game.Services;
using System;
using UnityEngine;

namespace RH.Game.Systems
{
    public class CreateSpellPainterSystem : IEcsRunSystem
    {
        private readonly StaticData _staticData;
        private EcsFilter<StartTouchInput, TouchInput> _filter;

        public void Run()
        {
            foreach (int i in _filter)
            {
                ref var entity = ref _filter.GetEntity(i);

                CreatePainter(ref _filter.Get2(i), ref entity);
                RemoveStartTouchComponent(ref entity);
            }
        }

        private void CreatePainter(ref TouchInput touchInput, ref EcsEntity entity)
        {
            Transform painter = GameObject.Instantiate(_staticData.SpellPainterPrefab, GameCamera.ScreenToWorldPoint(touchInput.Points[0]), Quaternion.identity);
            entity.Get<SpellPainter>().Transform = painter;
        }

        private void RemoveStartTouchComponent(ref EcsEntity entity)
        {
            entity.Del<StartTouchInput>();
        }
    }
}