using RH.Game.Settings;
using RH.Utilities.SingletonAccess;
using UnityEngine;

namespace RH.Game.Player
{
    [RequireComponent(typeof(Animator))]
    public class SwordHit : MonoBehaviourSingleton<SwordHit>
    {
        private Animator _animator;

        private void Awake()
        {
            _animator = GetComponent<Animator>();
        }

        public void Execute()
        {
            _animator.speed = 1 / GameSettings.Instance.SwordHitTime;
            _animator.SetTrigger("Attack");
        }
    }
}