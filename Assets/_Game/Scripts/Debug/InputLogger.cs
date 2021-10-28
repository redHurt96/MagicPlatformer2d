using UnityEngine;
using RH.Game.Settings;
using RH.Game.Input.Tracking;

namespace RH.Game.Debugging
{
    public class InputLogger : MonoBehaviour
    {
        private void Start()
        {
            if (!GameSettings.Instance.EnableInputLog)
            {
                Destroy(this);
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

        private void PrintPress() => Debug.Log("Press");
        private void PrintDrag() => Debug.Log("Drag");
        private void PrintRelease() => Debug.Log("Release");
    }
}