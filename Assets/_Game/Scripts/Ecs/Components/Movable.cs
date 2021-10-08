using RH.Game.UnityComponents;
using UnityEngine;

namespace RH.Game.Components
{
    public struct Movable
    {
        public Rigidbody2D Rigidbody;
        public GroundDetector GroundDetector;
        public float Speed;

        public Vector2 Position => Rigidbody.position;
    }
}