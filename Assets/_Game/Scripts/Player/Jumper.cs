using RH.Game.Data;
using UnityEngine;
using Zenject;

namespace RH.Game.Player
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class Jumper : MonoBehaviour
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

        public void Jump()
        {
            
        }
    }
}