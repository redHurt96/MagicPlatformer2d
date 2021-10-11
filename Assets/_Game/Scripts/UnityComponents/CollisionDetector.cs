using System.Collections.Generic;
using UnityEngine;

namespace RH.Game.UnityComponents
{
    public class CollisionDetector : MonoBehaviour
    {
        public bool IsGrounded => _colliders.Count > 0;

        private List<Collider2D> _colliders = new List<Collider2D>();

        protected virtual bool IsCollisionValid(Collision2D collision) => true;

        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (IsCollisionValid(collision))
                _colliders.Add(collision.collider);
        }

        private void OnCollisionExit2D(Collision2D collision)
        {
            _colliders.Remove(collision.collider);
        }
    }
}