using System;
using UnityEngine;
using UnityEngine.UI;
using RH.Game.Enums;

namespace RH.Game.UnityComponents.UI
{
    [RequireComponent(typeof(Button))]
    public class SpellButton : MonoBehaviour
    {
        public event Action<SpellType> SpellTypeChanged;

        [SerializeField] private SpellType _spellType;
        
        private Button _button;

        private void Awake()
        {
            _button = GetComponent<Button>();
            _button.onClick.AddListener(InvokeEvent);
        }

        private void OnDestroy()
        {
            _button.onClick.RemoveListener(InvokeEvent);
        }

        private void InvokeEvent()
        {
            SpellTypeChanged?.Invoke(_spellType);
        }
    }
}