using UnityEngine;

public class TargetFollowCamera : MonoBehaviour
{
    [SerializeField] private Transform _target;

    [Space]

    [SerializeField] private Vector3 _offset;
    [SerializeField] private float _smoothValue;

    private Transform _transform;

    public void AttachTarget(Transform target)
    {
        _target = target;
    }

    private void Start()
    {
        _transform = transform;
    }

    private void FixedUpdate()
    {
        if (_target == null)
            return;

        _transform.position = Vector3.Lerp(_transform.position, _target.position + _offset, _smoothValue);
    }
}
