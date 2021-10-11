using UnityEngine;

namespace RH.Game.Services
{
    public sealed class SpawnSystem
    {
        public static GameObject Spawn(GameObject prefab, Vector3 position)
        {
            return GameObject.Instantiate(prefab, position, Quaternion.identity);
        }
    }
}