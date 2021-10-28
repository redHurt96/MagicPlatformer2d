using RH.Game.Settings;
using UnityEngine;

namespace RH.Game.Input.Tracking
{
    public class InputLenght : MonoBehaviour
    {
        public static float LastLenght { get; private set; }
        
        private Vector2 _lastPoint;

        private Vector2 _screenPosition => TouchInputService.ScreenPosition;
        
        private void Start()
        {
            TouchInputService.Pressed += StartTrack;
            TouchInputService.Dragged += CollectPoint;
            TouchInputService.Released += CalculateLenght;
        }

        private void StartTrack()
        {
            LastLenght = 0f;
            _lastPoint = _screenPosition;
        }

        private void CollectPoint()
        {
            LastLenght += Vector2.Distance(_lastPoint, _screenPosition);
            _lastPoint = _screenPosition;
        }

        private void CalculateLenght()
        {
            LastLenght += Vector2.Distance(_lastPoint, _screenPosition);
            LastLenght /= Screen.width;
            
            LogLastLenght();
        }

        private void LogLastLenght()
        {
            if (GameSettings.Instance.EnableInputLog)
                Debug.Log($"Last input lenght = " + LastLenght);
        }
    }
}