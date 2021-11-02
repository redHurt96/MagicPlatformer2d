using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using RH.Game.Infrastructure;
using RH.Game.Settings;

namespace RH.Game.InputUiSelecting
{
    public class InputUiSelector : MonoBehaviour
    {
        [SerializeField] private InputUiCreator.InputType _type;
        [SerializeField] private GameSettings _gameSettings;

        private Button _button;

        private void Start()
        {
            _button = GetComponent<Button>();
            _button.onClick.AddListener(PerformOnClick);
        }

        private void PerformOnClick()
        {
            _gameSettings.MoveUiType = _type;
            SceneManager.LoadScene(1);
        }
    }
}