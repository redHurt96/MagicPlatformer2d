using System.Collections.Generic;
using UnityEngine;
using Zenject;
using RH.Game.Data;

namespace RH.Game.Player
{
    [RequireComponent(typeof(Collider2D))]
    public class CollisionDetector : MonoBehaviour
    {
        private readonly List<Collider2D> _colliders = new List<Collider2D>(2);

        private PlayerInLevelData _playerInLevelData;

        [Inject]
        private void Inject(PlayerInLevelData playerInLevelData)
        {
            _playerInLevelData = playerInLevelData;
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            _colliders.Add(collision.collider);
            UpdateInLevelData();
        }

        private void OnCollisionExit2D(Collision2D collision)
        {
            UpdateCollidersList(collision);
            UpdateInLevelData();

            void UpdateCollidersList(Collision2D collision)
            {
                var collider = collision.collider;

                if (_colliders.Contains(collider))
                    _colliders.Remove(collider);
            }
        }

        private void UpdateInLevelData() => _playerInLevelData.IsCollide = _colliders.Count > 0;
    }
}