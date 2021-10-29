using System;
using System.Collections.Generic;
using UnityEngine;
using RH.Game.Input.Tracking;

namespace RH.Game.Spells
{
    public class InputTracker
    {
        public event Action<List<Vector3>> DrawComplete;

        private List<Vector3> _drawPoints = new List<Vector3>();

        public void Init()
        {
            TouchInputService.Pressed += StartTrack;
            TouchInputService.Dragged += Track;
            TouchInputService.Released += FinishTrack;
        }

        public void Dispose()
        {
            TouchInputService.Pressed -= StartTrack;
            TouchInputService.Dragged -= Track;
            TouchInputService.Released -= FinishTrack;
        }

        private void StartTrack(Vector2 point)
        {
            _drawPoints = new List<Vector3>();
            AddPoint(point);
        }

        private void Track(Vector2 point)
        {
            AddPoint(point);
        }

        private void FinishTrack(Vector2 point)
        {
            AddPoint(point);
            DrawComplete?.Invoke(_drawPoints);
        }

        private void AddPoint(Vector2 point)
        {
            _drawPoints.Add(point);            
        }
    }
}