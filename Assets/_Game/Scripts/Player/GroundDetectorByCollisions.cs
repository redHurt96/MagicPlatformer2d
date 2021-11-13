using System.Collections.Generic;
using UnityEngine;

namespace RH.Game.Player
{
    public class GroundDetectorByCollisions : MonoBehaviour, IGroundDetector
    {
        public bool IsGrounded => _groundColliders.Count > 0;

        [SerializeField] private Transform _anchor;

        private List<Collider2D> _groundColliders = new List<Collider2D>();

        private void OnCollisionEnter2D(Collision2D other)
        {
            if (IsValidCollision(other))
                _groundColliders.Add(other.collider);
        }

        private void OnCollisionExit2D(Collision2D other)
        {
            if (_groundColliders.Contains(other.collider))
                _groundColliders.Remove(other.collider);
        }

        private bool IsValidCollision(Collision2D other)
        {
            bool isTrigger = other.collider.isTrigger;
            bool hasValidContactWithPlayer = false;

            for (int i = 0; i < other.contactCount; i++)
            {
                ContactPoint2D contact = other.GetContact(i);

                if (contact.otherCollider.transform == transform && contact.point.y < _anchor.position.y)
                {
                    hasValidContactWithPlayer = true;
                    break;
                }
            }

            return !isTrigger && hasValidContactWithPlayer;
        }
    }
}