using RH.Game.Input;
using UnityEngine;

namespace RH.Game.Player
{
    public class SurfaceSlider : MonoBehaviour
    {
        [SerializeField] private CollisionDetector _collisionDetector;
        private Vector2 _normal;

        public Vector2 Project(Vector2 axis)
        {
            return axis - Vector2.Dot(axis, _normal) * _normal;
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (_collisionDetector.IsGrounded)
                _normal = collision.contacts[0].normal;
        }

        private void OnDrawGizmos()
        {
            if (!Application.isPlaying)
                return;

            Vector3 position = transform.position;
            
            Gizmos.color = Color.white;
            Gizmos.DrawLine(position, position + new Vector3(_normal.x, _normal.y, 0f) * 3f);
            
            Gizmos.color = Color.red;
            var projectLeft = Project(Vector2.left);
            var projectRight = Project(Vector2.right);
            Gizmos.DrawLine(position, position + new Vector3(projectLeft.x, projectLeft.y, 0f) * 3f);
            Gizmos.DrawLine(position, position + new Vector3(projectRight.x, projectRight.y, 0f) * 3f);
        }
    }
}