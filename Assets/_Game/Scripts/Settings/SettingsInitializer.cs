using UnityEngine;

namespace RH.Game.Settings
{
    public class SettingsInitializer : MonoBehaviour
    {
        [SerializeField] private StaticData _settings;

        private void Awake()
        {
            _settings.Init();
            Destroy(gameObject);
        }
    }
}
