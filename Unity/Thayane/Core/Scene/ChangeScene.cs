using UnityEngine;
using UnityEngine.SceneManagement;

namespace Thayane.Core.Scene
{
    public class ChangeScene : MonoBehaviour
    {
        private static readonly string LoadingScene = "Loading";

        public void ChangeActualSceneAsync(string sceneName)
        {
            SceneLoading.SceneToLoad = sceneName;
            SceneManager.LoadScene(LoadingScene);
        }

        public void ChangeActualScene(string sceneName)
        {
            SceneManager.LoadScene(sceneName);
        }
    }
}
