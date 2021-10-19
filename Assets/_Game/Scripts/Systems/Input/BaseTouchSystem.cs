using System.Collections.Generic;
using UnityEngine;
using Leopotam.Ecs;
using RH.Game.Components;

namespace RH.Game.Systems
{
    public abstract class BaseTouchSystem : IEcsRunSystem
    {
        protected abstract bool UnderUi { get; }
        protected abstract bool HasTouch { get; }

        protected readonly EcsWorld _world;

        public void Run()
        {
            if (HasTouch && !UnderUi)
            {
                var entity = _world.NewEntity();

                ref var startTouchInput = ref entity.Get<StartTouchInput>();
                ref var touchInput = ref entity.Get<TouchInput>();

                InitTouchComponent(ref touchInput);
            }
        }

        private static void InitTouchComponent(ref TouchInput touchInput)
        {
            touchInput.Points = new List<Vector2>();
            touchInput.Points.Add(Input.mousePosition);
        }
    }
}