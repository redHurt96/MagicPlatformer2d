using UnityEngine;
using Zenject;
using RH.Game.Data;

namespace RH.Game.Player
{
    [RequireComponent(typeof(Rigidbody2D), typeof(CollisionDetector))]
    public class Mover : MonoBehaviour
    {
        private PlayerData _playerData;
        private Rigidbody2D _rigidbody;
        private CollisionDetector _collisionDetector;

        [Inject]
        private void Inject(PlayerData playerData)
        {
            _playerData = playerData;
        }

        private void Awake()
        {
            _rigidbody = GetComponent<Rigidbody2D>();
            _collisionDetector = GetComponent<CollisionDetector>();
        }

        public void Move(float axis)
        {
            if (_collisionDetector.IsCollide)
                MovePosition(axis);
        }

        private void MovePosition(float axis)
        {
            Vector2 offset = new Vector2(axis, 0f) * _playerData.Speed * Time.deltaTime;
            _rigidbody.MovePosition(_rigidbody.position + offset);
        }
    }
}