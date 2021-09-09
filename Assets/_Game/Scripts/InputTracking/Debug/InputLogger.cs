using RH.Game.Settings;
using UnityEngine;

namespace RH.Game.InputTracking.Debugging
{
    public class InputLogger : MonoBehaviour
    {
        private void Start()
        {
            if (!PrototypeSettings.Instance.EnableInputLog)
            {
                Destroy(this);
            }
            else
            {
                PlayerInput.Pressed += PrintPress;
                PlayerInput.Dragged += PrintDrag;
                PlayerInput.Released += PrintRelease;
            }
        }

        private void OnDestroy()
        {
            PlayerInput.Pressed -= PrintPress;
            PlayerInput.Dragged -= PrintDrag;
            PlayerInput.Released -= PrintRelease;
        }

        private void PrintPress() => Debug.Log("Press");
        private void PrintDrag() => Debug.Log("Drag");
        private void PrintRelease() => Debug.Log("Release");
    }
}