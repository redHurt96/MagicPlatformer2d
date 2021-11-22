using RH.Game.ManaManagement;
using UnityEngine;
using UnityEngine.UI;

namespace RH.Game.UI
{
    [RequireComponent(typeof(Slider))]
    public class ManaBar : MonoBehaviour
    {
        private Slider _slider;

        private void Start()
        {
            _slider = GetComponent<Slider>();

            Refresh();

            Mana.Instance.ValueChanged += Refresh;
        }

        private void OnDestroy()
        {
            if (Mana.Instance != null)
                Mana.Instance.ValueChanged -= Refresh;
        }

        private void Refresh() => 
            _slider.value = Mana.Instance.Value / Mana.Instance.MaxValue;
    }
}