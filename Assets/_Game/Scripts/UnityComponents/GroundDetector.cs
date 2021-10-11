using UnityEngine;

namespace RH.Game.UnityComponents
{
    public class GroundDetector : CollisionDetector
    {
        protected override bool IsCollisionValid(Collision2D collision)
        {
            return collision.GetContact(0).point.y < _groundAnchor.position.y;
        }

        [SerializeField] private Transform _groundAnchor;
    }
}