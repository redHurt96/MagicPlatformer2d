using System;
using System.Collections.Generic;
using UnityEngine;
using RH.Game.InputTracking;

namespace RH.Game.Spells
{
    public class InputTracker
    {
        public event Action<List<Vector3>> DrawComplete;

        private List<Vector3> _drawPoints = new List<Vector3>();

        public void Init()
        {
            PlayerInput.Pressed += StartTrack;
            PlayerInput.Dragged += Track;
            PlayerInput.Released += FinishTrack;
        }

        public void Dispose()
        {
            PlayerInput.Pressed -= StartTrack;
            PlayerInput.Released -= FinishTrack;
        }

        private void StartTrack()
        {
            _drawPoints = new List<Vector3>();
            AddPoint();
        }

        private void Track()
        {
            AddPoint();
        }

        private void FinishTrack()
        {
            AddPoint();
            DrawComplete?.Invoke(_drawPoints);
        }

        private void AddPoint()
        {
            _drawPoints.Add(PlayerInput.WorldPosition);            
        }
    }
}