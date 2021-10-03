using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RH.Game.Ecs.UnityComponents
{
    public class SceneData : MonoBehaviour
    {
        public Vector3 PlayerSpawnPosition => _playerSpawnPoint.position;
        
        [SerializeField] private Transform _playerSpawnPoint;
    }
}