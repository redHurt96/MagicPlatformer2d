using UnityEngine;
using RH.Game.Settings;

namespace RH.Game.PushPerforming
{
    public static class PushPerformer
    {
        private static Vector2 _pushAreaSize => GameSettings.Instance.PushAreaSize;

        public static void Push(Vector2 point, Vector2 direction, float force)
        {
            Collider2D[] colliders = FindOverlapingColliders(point, direction);

            PrintCollidersNames(colliders);
            TryPushObjects(colliders, force, direction);
        }

        private static Collider2D[] FindOverlapingColliders(Vector2 point, Vector2 direction)
        {
            Vector2 boxCenter = point + direction * _pushAreaSize.x;
            Collider2D[] colliders = Physics2D.OverlapBoxAll(boxCenter, _pushAreaSize, 0f);
            return colliders;
        }

        private static void TryPushObjects(Collider2D[] colliders, float force, Vector2 direction)
        {
            foreach (Collider2D collider in colliders)
            {
                if (collider.TryGetComponent<IPushable>(out var pushable))
                    pushable.TryPush(direction, force);
            }
        }

        private static void PrintCollidersNames(Collider2D[] colliders)
        {
            if (!GameSettings.Instance.PushPerformerLogsEnabled)
                return;

            foreach (Collider2D collider in colliders)
                Debug.Log(collider.gameObject.name);
        }
    }
}
