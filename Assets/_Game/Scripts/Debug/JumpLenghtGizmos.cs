using UnityEngine;
using RH.Game.Settings;

namespace RH.Game.Debugging
{
    public class JumpLenghtGizmos : MonoBehaviour
    {
        private void Awake()
        {
#if !UNITY_EDITOR
            Destroy(this);
#endif
        }

        private void OnDrawGizmosSelected()
        {
            if (PrototypeSettings.Instance == null || !PrototypeSettings.Instance.EnableJumpLog)
                return;

            Gizmos.color = Color.red;
            float jumpLenght = PrototypeSettings.Instance.MoveSpeed * PrototypeSettings.Instance.JumpTime;

            Gizmos.DrawLine(transform.position, transform.position + Vector3.right * jumpLenght);
            Gizmos.DrawLine(transform.position, transform.position + Vector3.left * jumpLenght);
            Gizmos.DrawLine(transform.position, transform.position + Vector3.up * PrototypeSettings.Instance.JumpHeight);
        }
    }
}