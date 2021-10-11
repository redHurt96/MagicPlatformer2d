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
                ref var touchInput = ref _world.NewEntity().Get<TouchInput>();
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