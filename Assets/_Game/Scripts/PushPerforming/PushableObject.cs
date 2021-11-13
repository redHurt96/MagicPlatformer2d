using RH.Utilities.Extensions;
using System.Collections;
using UnityEngine;

namespace RH.Game.PushPerforming
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class PushableObject : MonoBehaviour, IPushable
    {
        [SerializeField] private float _pushForceCoefficient = 1f;

        private Rigidbody2D _rigidbody;

        public void TryPush(Vector2 direction, float strenght) => Push(direction, strenght);

        private void Awake()
        {
            _rigidbody = GetComponent<Rigidbody2D>();
            DisableWhenStopped();
        }

        private void Push(Vector2 direction, float strenght)
        {
            SetRigidbodyType(RigidbodyType2D.Dynamic);
            _rigidbody.AddForce(direction * strenght * _pushForceCoefficient);
            DisableWhenStopped();
        }

        private void DisableWhenStopped() => StartCoroutine(ChangeBodyTypeWhenStopped());

        private IEnumerator ChangeBodyTypeWhenStopped()
        {
            yield return new WaitForSeconds(.5f);
            yield return new WaitUntil(() => _rigidbody.velocity.Approximately(Vector2.zero));
            SetRigidbodyType(RigidbodyType2D.Kinematic);
        }

        private void SetRigidbodyType(RigidbodyType2D type) =>
            _rigidbody.bodyType = type;
    }
}
