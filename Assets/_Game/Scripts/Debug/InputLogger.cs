using UnityEngine;
using RH.Game.Settings;
using RH.Game.Input.Tracking;

namespace RH.Game.Debugging
{
    public class InputLogger : MonoBehaviour
    {
        private void Start()
        {
            if (!GameSettings.Instance.InputLogEnabled)
            {
                Destroy(gameObject);
            }
            else
            {
                TouchInputService.Pressed += PrintPress;
                TouchInputService.Dragged += PrintDrag;
                TouchInputService.Released += PrintRelease;
            }
        }

        private void OnDestroy()
        {
            TouchInputService.Pressed -= PrintPress;
            TouchInputService.Dragged -= PrintDrag;
            TouchInputService.Released -= PrintRelease;
        }

        private void PrintPress(Vector2 point) => Debug.Log("Press at " + point);
        private void PrintDrag(Vector2 point) => Debug.Log("Drag at " + point);
        private void PrintRelease(Vector2 point) => Debug.Log("Release at" + point);
    }
}