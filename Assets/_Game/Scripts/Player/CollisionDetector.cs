using System.Collections.Generic;
using UnityEngine;

namespace RH.Game.Player
{
    public class CollisionDetector : MonoBehaviour
    {
        public bool IsCollide => _otherColliders.Count > 0;
        public bool IsGrounded => _groundColliders.Count > 0;

        private readonly List<Collider2D> _otherColliders = new List<Collider2D>();
        private readonly List<Collider2D> _groundColliders = new List<Collider2D>();

        [SerializeField] private Transform _groundedAnchor;

        private void OnCollisionEnter2D(Collision2D other)
        {
            _otherColliders.Add(other.collider);

            if (other.GetContact(0).point.y < _groundedAnchor.position.y)
                _groundColliders.Add(other.collider);
        }

        private void OnCollisionExit2D(Collision2D other)
        {
            Collider2D collider = other.collider;

            _otherColliders.Remove(collider);

            if (_groundColliders.Contains(collider))
                _groundColliders.Remove(collider);
        }
    }
}