using Leopotam.Ecs;
using RH.Game.Components;
using RH.Game.UnityComponents;
using UnityEngine;

namespace RH.Game.Services
{
    public sealed class MovableSpawnSystem
    {
        public static void Init(ref EcsEntity entity, GameObject prefab, Vector2 position, float speed)
        {
            ref var movable = ref entity.Get<Movable>();
            var gameObject = GameObject.Instantiate(prefab, position, Quaternion.identity);

            movable.Rigidbody = gameObject.GetComponent<Rigidbody2D>();
            movable.GroundDetector = gameObject.GetComponent<GroundDetector>();
            movable.Speed = speed;
        }
    }
}