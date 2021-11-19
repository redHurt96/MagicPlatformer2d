using System;
using System.Collections.Generic;
using UnityEngine;

namespace RH.Game.Spells
{
    public interface IInputTracker
    {
        event Action<List<Vector3>> DrawComplete;

        void Dispose();
        void Init();
    }
}