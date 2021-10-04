using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

namespace RH.Game.UnityComponents
{
    public class SceneData : MonoBehaviour
    {
        public Vector3 PlayerSpawnPosition => _playerSpawnPoint.position;
        public CinemachineVirtualCamera Camera => _camera;
        
        [SerializeField] private Transform _playerSpawnPoint;
        [SerializeField] private CinemachineVirtualCamera _camera;
    }
}