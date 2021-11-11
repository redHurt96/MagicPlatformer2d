using RH.Game.Spells;
using UnityEngine;

namespace RH.Game.LevelObjects.SpellsChanging
{
    [RequireComponent(typeof(Collider2D))]
    public class SpellsChangingTrigger : MonoBehaviour
    {
        private void OnTriggerExit2D(Collider2D collision)
        {
            if (IsPlayerCollide(collision))
                SpellsInitializer.Instance.ChangeCastType();
        }

        private static bool IsPlayerCollide(Collider2D collider) =>
            collider.CompareTag(Tags.PLAYER_TAG);
    }
}