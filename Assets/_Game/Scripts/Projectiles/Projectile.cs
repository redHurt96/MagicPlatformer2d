using System.Collections;
using UnityEngine;
using Between.Interfaces;

namespace RH.Game.Projectiles
{
    [RequireComponent(typeof(Rigidbody2D))]
    public partial class Projectile : MonoBehaviour
    {
        private Rigidbody2D _rigidbody2D;
        private ProjectileData _data;

        public void Init(ProjectileData data)
        {
            _data = data;
            _rigidbody2D = GetComponent<Rigidbody2D>();

            StartCoroutine(DelayedDestroy());
        }

        public void Launch(Vector3 direction)
        {
            _rigidbody2D.velocity = direction * _data.Speed;
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.isTrigger)
                return;

            if (other.TryGetComponent<IDamagable>(out var damagable))
                damagable.ApplyDamage(_data.Damage);

            Destroy();
        }

        private IEnumerator DelayedDestroy()
        {
            yield return new WaitForSeconds(_data.LifeTime);

            if (this != null)
                Destroy();
        }

        private void Destroy() => Destroy(gameObject);
    }
}