using System;
using RH.Game.Settings;
using UnityEngine;

public class JumpCurveGizmos : MonoBehaviour
{
    private void Awake()
    {
#if !UNITY_EDITOR
        Destroy(gameObject);
#endif
    }

    private void OnDrawGizmos()
    {
        if (!Application.isPlaying || !PrototypeSettings.Instance.EnableJumpGizmos)
            return;

        Gizmos.color = Color.red;
        var position = transform.position;

        Gizmos.DrawLine(position, position + Vector3.up * PrototypeSettings.Instance.JumpHeight);
        Gizmos.DrawLine(position, position + Vector3.right * PrototypeSettings.Instance.JumpLenght);
        Gizmos.DrawLine(position, position + Vector3.left * PrototypeSettings.Instance.JumpLenght);
    }
}
