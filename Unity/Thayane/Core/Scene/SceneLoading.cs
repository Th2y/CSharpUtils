using System;
using System.Collections;
using Thayane.Core.Utils;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Thayane.Core.Scene
{
    public class SceneLoading : MonoBehaviour
    {
        [SerializeField] private Slider loadingSlider;
        [SerializeField] private TextMeshProUGUI progressText;

        [NonSerialized] public static string SceneToLoad;

        private void Start()
        {
            StartCoroutine(LoadScene());
        }

        private IEnumerator LoadScene()
        {
            AsyncOperation asyncOperation = SceneManager.LoadSceneAsync(SceneToLoad);
            asyncOperation.allowSceneActivation = false;

            while (!asyncOperation.isDone)
            {
                float progress = Mathf.Clamp01(asyncOperation.progress / 0.9f);
                loadingSlider.value = progress;
                progressText.text = Mathf.Round(progress * 100f) + "%";

                if (asyncOperation.progress >= 0.9f)
                {
                    yield return new WaitForSeconds(1);
                    asyncOperation.allowSceneActivation = true;
                }

                yield return null;
            }
        }
    }
}
