using UnityEngine;
using Leopotam.Ecs;
using RH.Game.Components;
using System.Collections.Generic;

namespace RH.Game.Systems
{
    public class StartTouchSystem : IEcsRunSystem
    {
        private readonly EcsWorld _world;

        public void Run()
        {
            if (Input.GetMouseButtonDown(0))
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