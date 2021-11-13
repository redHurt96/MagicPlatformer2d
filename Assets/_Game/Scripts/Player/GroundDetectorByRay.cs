using UnityEngine;

namespace RH.Game.Player
{
    public class GroundDetectorByRay : MonoBehaviour, IGroundDetector
    {
        public bool IsGrounded { get; private set; }

        [SerializeField] private Transform _rayAnchor;
        [SerializeField] private float _distance;

        private void Update()
        {
            RaycastHit2D hit = Physics2D.Raycast(_rayAnchor.position, Vector2.down, _distance);
            IsGrounded = hit.collider != null;
        }

        private void OnDrawGizmosSelected()
        {
            Gizmos.color = Color.red;
            Gizmos.DrawLine(_rayAnchor.position, _rayAnchor.position + Vector3.down * _distance);
        }

    }
}