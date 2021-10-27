using UnityEngine.SceneManagement;

namespace RH.Game.UI
{
    public class RestartSceneButton : BaseButton
    {
        protected override void PerformOnClick()
        {
            SceneManager.LoadScene(0);
        }
    }
}