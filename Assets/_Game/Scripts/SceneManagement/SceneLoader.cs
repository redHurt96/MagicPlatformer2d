using UnityEngine;
using UnityEngine.SceneManagement;

namespace RH.Game.SceneManagement
{
    public class SceneLoader : MonoBehaviour
    {
        public void LoadScene(int withBuildIndex)
        {
            SceneManager.LoadScene(withBuildIndex);
        }
    }
}