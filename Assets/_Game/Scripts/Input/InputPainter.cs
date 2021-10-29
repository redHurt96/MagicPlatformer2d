using RH.Game.Input.Tracking;
using UnityEngine;
using Sirenix.OdinInspector;
using Between;

namespace RH.Game.Input
{
    public class InputPainter : MonoBehaviour
    {
        [AssetsOnly, Required("Required"), SerializeField] private GameObject _prefab;
        
        private GameObject _currentPainter;

        private void Start()
        {
            TouchInputService.Pressed += CreatePainter;
            TouchInputService.Dragged += MovePainter;
            TouchInputService.Released += DestroyPainter;
        }

        private void OnDestroy()
        {
            TouchInputService.Pressed -= CreatePainter;
            TouchInputService.Dragged -= MovePainter;
            TouchInputService.Released -= DestroyPainter;
        }

        private void CreatePainter(Vector2 point)
        {
            if (_currentPainter != null)
                Destroy(_currentPainter.gameObject);

            _currentPainter = Instantiate(_prefab, point, Quaternion.identity);
        }

        private void MovePainter(Vector2 point)
        {
            if (_currentPainter != null)
                _currentPainter.transform.position = point;
        }

        private void DestroyPainter(Vector2 point)
        {
            if (_currentPainter != null)
                Destroy(_currentPainter.gameObject);
        }
    }
}