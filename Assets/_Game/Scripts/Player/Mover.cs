using RH.Game.Data;
using UnityEngine;
using Zenject;

namespace RH.Game.Player
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class Mover : MonoBehaviour
    {
        private PlayerData _playerData;
        private Rigidbody2D _rigidbody;

        [Inject]
        private void Inject(PlayerData playerData)
        {
            _playerData = playerData;
        }

        private void Awake()
        {
            _rigidbody = GetComponent<Rigidbody2D>();
        }

        public void Move(float axis)
        {
            Vector2 offset = new Vector2(axis, 0f) * _playerData.Speed * Time.deltaTime;

            _rigidbody.MovePosition(_rigidbody.position + offset);
        }
    }
}