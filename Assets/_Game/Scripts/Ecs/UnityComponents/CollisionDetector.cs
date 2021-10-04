using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RH.Game.UnityComponents
{
    public class CollisionDetector : MonoBehaviour
    {
        public bool IsColliding => _colliders.Count > 0;

        private List<Collider2D> _colliders = new List<Collider2D>();

        private void OnCollisionEnter2D(Collision2D collision)
        {
            _colliders.Add(collision.collider);
        }

        private void OnCollisionExit2D(Collision2D collision)
        {
            _colliders.Remove(collision.collider);
        }
    }
}