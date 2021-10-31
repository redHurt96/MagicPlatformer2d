using UnityEngine;
using SimpleInputNamespace;

namespace RH.Game.Input
{
    [RequireComponent(typeof(AxisInputUIArrows))]
    public class JoystickInputInvoker : MonoBehaviour, IMovementInputServiceHandler
    {
        private AxisInputUIArrows _arrows;

        private void Awake()
        {
            _arrows = GetComponent<AxisInputUIArrows>();
        }

        private void Update()
        {
            MovementInputService.SetDirection(_arrows.Value.x, this);
        }
    }
}