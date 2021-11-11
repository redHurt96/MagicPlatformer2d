using System.Collections.Generic;
using UnityEngine;

namespace RH.Game.Player
{
    public class CollisionDetector : MonoBehaviour
    {
        public bool IsCollide => _otherColliders.Count > 0;

        private readonly List<Collider2D> _otherColliders = new List<Collider2D>();

        private void OnCollisionEnter2D(Collision2D other)
        {
            if (other.collider.isTrigger)
                return;

            _otherColliders.Add(other.collider);
        }

        private void OnCollisionExit2D(Collision2D other)
        {
            if (other.collider.isTrigger)
                return;

            _otherColliders.Remove(other.collider);
        }
    }
}