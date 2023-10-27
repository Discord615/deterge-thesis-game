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
        Time.timeScale = 1;
        StartCoroutine(LoadSceneAsync(sceneId));
    }

    IEnumerator LoadSceneAsync(int sceneId){
        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneId);

        loadingScreenPanel.SetActive(true);
        operation.allowSceneActivation = false;

        float progressValue = 0;

        while (!operation.isDone){
            progressValue = Mathf.MoveTowards(progressValue, operation.progress, Time.deltaTime);

            loadingBarFill.value = progressValue;

            if (progressValue >= 0.9f){
                progressValue = 1;
                operation.allowSceneActivation = true;
            }

            yield return null;
        }
    }
}
