using RH.Game.Player.Movement.Actions;
using RH.Game.Player.Movement.Desicions;
using RH.Utilities.StateMachine2;
using UnityEngine;

namespace RH.Game.Player.Movement
{
    public class MovementController : MonoBehaviour
    {
        [SerializeField] private Rigidbody2D _rigidbody;
        [SerializeField] private SurfaceSlider _surfaceSlider;
        [SerializeField] private CollisionDetector _collisionDetector;
        
        private StateMachine _stateMachine;

        private void InitStateMachine()
        {
            
        }
    }
}