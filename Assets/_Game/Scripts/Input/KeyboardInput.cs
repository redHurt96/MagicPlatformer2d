using System;
using UnityEngine;

namespace RH.Game.UserInput
{
    public class KeyboardInput : MonoBehaviour
    {
        public static event Action<Vector2> OnInput;
        public static float Direction;

        private void Awake()
        {
            if (!Application.isEditor)
                Destroy(gameObject);
        }

        private void Update()
        {
            float horizontal = Input.GetAxisRaw("Horizontal");
            Direction = horizontal;
            OnInput?.Invoke(new Vector2(horizontal, 0f));
        }
    }
}