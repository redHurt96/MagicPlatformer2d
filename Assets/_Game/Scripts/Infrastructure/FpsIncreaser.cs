using UnityEngine;

namespace RH.Game.Infrastructure
{
    public static class FpsIncreaser
    {
        public static void Perform()
        {
            Application.targetFrameRate = 60;
        }
    }
}