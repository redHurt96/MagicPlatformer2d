using System.Collections.Generic;
using UnityEngine;

namespace RH.Game.Player
{
    public class GroundDetector : MonoBehaviour
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
            if (IsValidCollision(other))
                _groundColliders.Remove(other.collider);
        }

        private bool IsValidCollision(Collision2D other) =>
            !other.collider.isTrigger && other.transform.position.y < _anchor.position.y;
    }
}