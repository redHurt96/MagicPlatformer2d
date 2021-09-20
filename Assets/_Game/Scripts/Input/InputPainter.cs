using RH.Game.Input.Tracking;
using UnityEngine;
using Sirenix.OdinInspector;

namespace RH.Game.Input
{
    public class InputPainter : MonoBehaviour
    {
        [AssetsOnly, Required("Required"), SerializeField] private GameObject _prefab;
        
        private GameObject _currentPainter;

        private void Start()
        {
            TouchInput.Pressed += CreatePainter;
            TouchInput.Dragged += MovePainter;
            TouchInput.Released += DestroyPainter;
        }

        private void OnDestroy()
        {
            TouchInput.Pressed -= CreatePainter;
            TouchInput.Dragged -= MovePainter;
            TouchInput.Released -= DestroyPainter;
        }

        private void CreatePainter()
        {
            if (_currentPainter != null)
                Destroy(_currentPainter.gameObject);

            _currentPainter = Instantiate(_prefab, TouchInput.WorldPosition, Quaternion.identity);
        }

        private void MovePainter()
        {
            if (_currentPainter != null)
                _currentPainter.transform.position = TouchInput.WorldPosition;
        }

        private void DestroyPainter()
        {
            if (_currentPainter != null)
                Destroy(_currentPainter.gameObject);
        }
    }
}