using RH.Game.UnityComponents;
using UnityEngine;

namespace RH.Game.Components 
{
    public struct Player
    {
        public Rigidbody2D Rigidbody;
        public SurfaceSlider SurfaceSlider;
        public GroundDetector GroundDetector;
    }
}