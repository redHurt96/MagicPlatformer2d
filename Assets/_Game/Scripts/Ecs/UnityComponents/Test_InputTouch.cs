using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Test_InputTouch : MonoBehaviour
{
    public Text _text;
    public Text _secondText;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            _text.text = $"{EventSystem.current.IsPointerOverGameObject()}";

#if UNITY_ANDROID && !UNITY_EDITOR
            _secondText.text = $"{EventSystem.current.IsPointerOverGameObject(Input.GetTouch(0).fingerId)}";
#endif
        }
    }
}
