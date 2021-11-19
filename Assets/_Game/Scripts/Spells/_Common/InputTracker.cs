using System;
using System.Collections.Generic;
using UnityEngine;
using RH.Game.Input.Tracking;

namespace RH.Game.Spells
{
    public abstract class BaseInputTracker : IInputTracker
    {
        public event Action<List<Vector3>> DrawComplete;

        protected List<Vector3> _drawPoints { get; private set; } = new List<Vector3>();

        private bool _isBreak = false;

        public void Init()
        {
            TouchInputService.Pressed += Start;
            TouchInputService.Dragged += Track;
            TouchInputService.Released += Finish;
        }

        public void Dispose()
        {
            TouchInputService.Pressed -= Start;
            TouchInputService.Dragged -= Track;
            TouchInputService.Released -= Finish;
        }

        protected virtual void PerformOnTrack() { }

        private void Start(Vector2 point)
        {
            _isBreak = false;
            _drawPoints = new List<Vector3>();

            AddPoint(point);
        }

        private void Track(Vector2 point)
        {
            if (_isBreak)
                return;

            AddPoint(point);
            PerformOnTrack();
        }

        private void Finish(Vector2 point)
        {
            if (_isBreak)
                return;

            AddPoint(point);
            InvokeCompleteEvent();
        }

        protected void Break()
        {
            _isBreak = true;
            InvokeCompleteEvent();
        }

        private void InvokeCompleteEvent() => 
            DrawComplete?.Invoke(_drawPoints);

        private void AddPoint(Vector2 point) => 
            _drawPoints.Add(point);
    }

    public class InputTracker : BaseInputTracker
    {

    }
}