using UnityEngine.EventSystems;

namespace RH.Game.Input.Tracking
{
    public static class UnderUiTouchDetector
    {
        public static bool IsUnderUi
        {
            get
            {
#if UNITY_ANDROID && !UNITY_EDITOR
                return DetectTouchOnAndroid();
#else
                return EventSystem.current.IsPointerOverGameObject();
#endif                
            }
        }
        
        private static bool DetectTouchOnAndroid()
        {
            for (int i = 0; i < UnityEngine.Input.touchCount; i++)
            {
                if (!EventSystem.current.IsPointerOverGameObject(UnityEngine.Input.GetTouch(i).fingerId))
                    return true;
            }

            return false;
        }
    }
}