using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LoadingScreen : MonoBehaviour
{
    [SerializeField] private GameObject loadingScreenPanel;
    [SerializeField] private Slider loadingBarFill;

    public void LoadScene(int sceneId){
        StartCoroutine(LoadSceneAsync(sceneId));
    }

    IEnumerator LoadSceneAsync(int sceneId){
        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneId);

        loadingScreenPanel.SetActive(true);

        while (!operation.isDone){
            float progressValue = Mathf.Clamp01(operation.progress / 0.9f);

            loadingBarFill.value = progressValue;

            yield return null;
        }
    }
}
