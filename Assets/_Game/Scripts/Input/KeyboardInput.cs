using System;
using UnityEngine;

namespace RH.Game.Input
{
    public class KeyboardInput : MonoBehaviour
    {
        public static event Action<Vector2> OnInput;
        public static float Direction;
        public static bool IsMoving => Mathf.Approximately(Direction, 0f);
        public static bool JumpButtonPressed => UnityEngine.Input.GetKeyDown(KeyCode.Space);

        private void Awake()
        {
            if (!Application.isEditor)
                Destroy(gameObject);
        }

        private void Update()
        {
            float horizontal = UnityEngine.Input.GetAxisRaw("Horizontal");
            Direction = horizontal;
            OnInput?.Invoke(new Vector2(horizontal, 0f));
        }
    }
}