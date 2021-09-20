using RH.Game.Settings;
using UnityEngine;

namespace RH.Game.Input.Tracking
{
    public class InputLenght : MonoBehaviour
    {
        public static float LastLenght { get; private set; }
        
        private Vector2 _lastPoint;
        
        private void Start()
        {
            TouchInput.Pressed += StartTrack;
            TouchInput.Dragged += CollectPoint;
            TouchInput.Released += CalculateLenght;
        }

        private void StartTrack()
        {
            LastLenght = 0f;
            _lastPoint = TouchInput.ScreenPosition;
        }

        private void CollectPoint()
        {
            LastLenght += Vector2.Distance(_lastPoint, TouchInput.ScreenPosition);
            _lastPoint = TouchInput.ScreenPosition;
        }

        private void CalculateLenght()
        {
            LastLenght += Vector2.Distance(_lastPoint, TouchInput.ScreenPosition);
            LastLenght /= Screen.width;
            
            LogLastLenght();
        }

        private void LogLastLenght()
        {
            if (PrototypeSettings.Instance.EnableInputLog)
                Debug.Log($"Last input lenght = " + LastLenght);
        }
    }
}