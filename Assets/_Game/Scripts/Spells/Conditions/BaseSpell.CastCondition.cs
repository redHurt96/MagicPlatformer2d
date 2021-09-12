﻿using System.Collections.Generic;
using UnityEngine;

namespace RH.Game.Spells
{
    public abstract partial class BaseSpell
    {
        public abstract class CastCondition
        {
            public abstract bool CanCast(List<Vector3> points);
        }
    }
}