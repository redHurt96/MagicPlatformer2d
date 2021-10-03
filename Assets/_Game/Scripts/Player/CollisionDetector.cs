using System.Collections.Generic;
using RH.Game.Settings;
using UnityEngine;

namespace RH.Game.Player
{
    public class CollisionDetector : MonoBehaviour
    {
        public bool IsCollide => _otherColliders.Count > 0;
        public bool IsGrounded => _groundColliders.Count > 0;

        private readonly List<Collider2D> _otherColliders = new List<Collider2D>();
        private readonly List<Collider2D> _groundColliders = new List<Collider2D>();

        [SerializeField] private Rigidbody2D _rigidbody;

        private void OnCollisionEnter2D(Collision2D other)
        {
            _otherColliders.Add(other.collider);
            _rigidbody.sharedMaterial.friction = IsGrounded ? StaticData.Instance.BodyFriction : 0f;
        }

        private void OnCollisionExit2D(Collision2D other)
        {
            _otherColliders.Remove(other.collider);
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            _groundColliders.Add(other);
        }
        
        private void OnTriggerExit2D(Collider2D other)
        {
            _groundColliders.Remove(other);
        }
    }
}