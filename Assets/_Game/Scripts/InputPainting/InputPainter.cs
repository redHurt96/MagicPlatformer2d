using UnityEngine;
using RH.Game.InputTracking;
using Sirenix.OdinInspector;

namespace RH.Game.InputPainting
{
    public class InputPainter : MonoBehaviour
    {
        [AssetsOnly, Required("Required"), SerializeField] private GameObject _prefab;
        
        private GameObject _currentPainter;

        private void Start()
        {
            PlayerInput.Pressed += CreatePainter;
            PlayerInput.Dragged += MovePainter;
            PlayerInput.Released += DestroyPainter;
        }

        private void OnDestroy()
        {
            PlayerInput.Pressed -= CreatePainter;
            PlayerInput.Dragged -= MovePainter;
            PlayerInput.Released -= DestroyPainter;
        }

        private void CreatePainter()
        {
            if (_currentPainter != null)
                Destroy(_currentPainter.gameObject);

            _currentPainter = Instantiate(_prefab, PlayerInput.WorldPosition, Quaternion.identity);
        }

        private void MovePainter()
        {
            if (_currentPainter != null)
                _currentPainter.transform.position = PlayerInput.WorldPosition;
        }

        private void DestroyPainter()
        {
            if (_currentPainter != null)
                Destroy(_currentPainter.gameObject);
        }
    }
}