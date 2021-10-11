using System.Collections.Generic;
using UnityEngine;

namespace RH.Game.UnityComponents
{
    public class GroundDetector : MonoBehaviour
    {
        public bool IsGrounded => _colliders.Count > 0;

        [SerializeField] private Transform _groundAnchor;

        private List<Collider2D> _colliders = new List<Collider2D>();

        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.GetContact(0).point.y < _groundAnchor.position.y)
                _colliders.Add(collision.collider);
        }

        private void OnCollisionExit2D(Collision2D collision)
        {
            _colliders.Remove(collision.collider);
        }
    }
}