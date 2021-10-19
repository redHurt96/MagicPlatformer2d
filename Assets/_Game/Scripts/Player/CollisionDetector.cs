using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace RH.Game.Player
{
    [RequireComponent(typeof(Collider2D))]
    public class CollisionDetector : MonoBehaviour
    {
        public bool IsCollide => _colliders.Count > 0;

        private List<Collider2D> _colliders = new List<Collider2D>(2);

        private void OnCollisionEnter2D(Collision2D collision)
        {
            _colliders.Add(collision.collider);
        }

        private void OnCollisionExit2D(Collision2D collision)
        {
            var collider = collision.collider;

            if (_colliders.Contains(collider))
                _colliders.Remove(collider);
        }
    }
}