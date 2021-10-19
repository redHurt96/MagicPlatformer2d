using UnityEngine;
using Zenject;
using RH.Game.Settings;

namespace RH.Game.Player
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class Jumper : MonoBehaviour
    {
        private PlayerSettings _playerData;
        private Rigidbody2D _rigidbody;

        [Inject]
        private void Inject(PlayerSettings playerData)
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