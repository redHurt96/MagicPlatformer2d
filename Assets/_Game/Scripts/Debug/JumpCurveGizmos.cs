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
        if (!Application.isPlaying || !StaticData.Instance.EnableJumpGizmos)
            return;

        Gizmos.color = Color.red;
        var position = transform.position;

        Gizmos.DrawLine(position, position + Vector3.up * StaticData.Instance.JumpHeight);
        Gizmos.DrawLine(position, position + Vector3.right * StaticData.Instance.JumpLenght);
        Gizmos.DrawLine(position, position + Vector3.left * StaticData.Instance.JumpLenght);
    }
}
