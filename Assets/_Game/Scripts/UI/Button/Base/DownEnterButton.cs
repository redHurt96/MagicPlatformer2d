using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.EventSystems;

namespace RH.Game.UI
{
    /// <summary>
    /// Для корректной работы необходимо, чтобы пивот на объекте не был установлен в (..,0), иначе валидная точка входа будет совпадать с центром объекта
    /// </summary>
    public abstract class DownEnterButton : MonoBehaviour, IPointerEnterHandler
    {
        public void OnPointerEnter(PointerEventData eventData)
        {
            if (eventData.position.y < transform.position.y)
                PerformOnEnter();
        }

        protected abstract void PerformOnEnter();
    }
}