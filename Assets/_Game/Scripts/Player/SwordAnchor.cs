using RH.Utilities.SingletonAccess;
using Sirenix.OdinInspector;
using UnityEngine;

namespace RH.Game.Player
{
    public class SwordAnchor : MonoBehaviourSingleton<SwordAnchor>
    {
        [SerializeField, Required] private GameObject _swordHitPrefab;

        public void CreateSword()
        {
            Instantiate(_swordHitPrefab, transform);
            Destroy(this);
        }
    }
}