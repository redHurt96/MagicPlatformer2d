using UnityEngine;
using Zenject;
using RH.Game.Data;
using RH.Game.Settings;

namespace RH.Game.Player
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class Mover : MonoBehaviour
    {
        private PlayerInLevelData _playerInLevelData;
        private PlayerSettings _playerData;
        private Rigidbody2D _rigidbody;

        [Inject]
        private void Inject(PlayerSettings playerData, PlayerInLevelData playerInLevelData)
        {
            _playerData = playerData;
            _playerInLevelData = playerInLevelData;
            _rigidbody = GetComponent<Rigidbody2D>();
        }

        private void Awake()
        {
            
        }

        public void Move(float axis)
        {
            if (_playerInLevelData.IsCollide)
                MovePosition(axis);
        }

        private void MovePosition(float axis)
        {
            Vector2 offset = new Vector2(axis, 0f) * _playerData.Speed * Time.deltaTime;
            _rigidbody.MovePosition(_rigidbody.position + offset);
        }
    }
}