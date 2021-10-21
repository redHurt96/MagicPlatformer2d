using UnityEngine;
using UnityEngine.UI;
using RH.Game.Spells;
using System.Collections;

namespace RH.Game.UI
{
    public class SpellsButtonsBar : MonoBehaviour
    {
        [SerializeField] private Button[] _buttons;
        [SerializeField] private int _default;

        private WaitUntil _waitSpells = new WaitUntil(() => SpellsCollection.Instance != null);

        private IEnumerator Start()
        {
            yield return _waitSpells;

            Select(_default);
            AttachListeners();
        }

        private void OnDestroy()
        {
            DetachListeners();
        }

        private void Select(int spellNumber)
        {
            SpellsCollection.Instance.SelectSpell((SpellType) spellNumber);
        }

        private void AttachListeners()
        {
            for (int i = 0; i < _buttons.Length; i++)
            {
                var spellNumber = i;
                _buttons[i].onClick.AddListener(() => Select(spellNumber));
            }
        }

        private void DetachListeners()
        {
            for (int i = 0; i < _buttons.Length; i++)
                _buttons[i].onClick.RemoveAllListeners();
        }
    }
}