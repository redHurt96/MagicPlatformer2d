using UnityEngine;

namespace RH.Game.Player
{
    public abstract class BaseGroundDetector : MonoBehaviour, IGroundDetector
    {
        public abstract bool IsGrounded { get; }
    }
}