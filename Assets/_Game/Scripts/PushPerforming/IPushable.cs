using UnityEngine;

namespace RH.Game.PushPerforming
{
    internal interface IPushable
    {
        void TryPush(Vector2 direction, float strenght);
    }
}
