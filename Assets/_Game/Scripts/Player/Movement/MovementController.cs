using RH.Game.Player;
using RH.Game.Player.Movement;
using UnityEngine;
using RH.Utilities.StateMachine2;

public class MovementController : MonoBehaviour
{
    [SerializeField] private SurfaceSlider _surfaceSlider;
    
    private StateMachine _stateMachine;
    
    private void InitStateMachine()
    {
        _stateMachine = new StateMachine();

        var idleState = new State(_stateMachine);
        var moveState = new State(_stateMachine);
        var jumpState = new State(_stateMachine);
        var fallState = new State(_stateMachine);

        var _transform = transform;
        var moveAction = new MoveAction(_transform, _surfaceSlider);
        var jumpAction = new JumpAction(_transform);
    }
}
