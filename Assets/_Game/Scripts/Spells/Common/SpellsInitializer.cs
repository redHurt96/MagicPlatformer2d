using UnityEngine;

namespace RH.Game.Spells
{
    public class SpellsInitializer : MonoBehaviour
    {
        private void Awake()
        {
            new SpellsCollection();
        }

        private void OnDestroy()
        {
            SpellsCollection.DestroyInstance();
        }
    }
}
