using UnityEngine;
using UnityEngine.UI;

namespace RH.Game.UI
{
    [RequireComponent(typeof(Button))]
    public abstract class BaseButton : MonoBehaviour
    {
        private Button _button;

        protected abstract void PerformOnClick();

        private void Awake()
        {
            _button = GetComponent<Button>();
            _button.onClick.AddListener(PerformOnClick);
        }

        private void OnDestroy()
        {
            _button.onClick.RemoveListener(PerformOnClick);
        } 
    }
}