using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RH.Game.Player
{
    public class CollisionDetector : MonoBehaviour
    {
        public bool IsCollide => _colliders.Count > 0;
        
        private readonly List<Collider2D> _colliders = new List<Collider2D>(); 
        
        private void OnCollisionEnter2D(Collision2D other)
        {
            _colliders.Add(other.collider);
        }

        private void OnCollisionExit2D(Collision2D other)
        {
            _colliders.Remove(other.collider);
        }
    }
}