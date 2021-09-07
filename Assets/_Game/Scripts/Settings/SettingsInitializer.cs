using UnityEngine;

namespace RH.Game.Settings
{
    public class SettingsInitializer : MonoBehaviour
    {
        [SerializeField] private PrototypeSettings _settings;

        private void Awake()
        {
            _settings.Init();
        }
    }
}
