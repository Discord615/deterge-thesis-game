using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LoadingScreen : MonoBehaviour
{
    public static LoadingScreen instance { get; private set; }

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogError("More than one instance of Loading Screen in current scene");
        }
        instance = this;
    }

    [SerializeField] private GameObject loadingScreenPanel;
    [SerializeField] private Slider loadingBarFill;

    [SerializeField] private bool testing;

    public void LoadScene(int sceneId)
    {
        Time.timeScale = 1;

        StartCoroutine(LoadSceneAsync(testing && sceneId == 1 ? 2 : sceneId));
    }

    IEnumerator LoadSceneAsync(int sceneId)
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneId, LoadSceneMode.Single);

        loadingScreenPanel.SetActive(true);
        operation.allowSceneActivation = false;

        float progressValue = 0;

        while (!operation.isDone)
        {
            progressValue = Mathf.MoveTowards(progressValue, operation.progress, Time.deltaTime);

            loadingBarFill.value = progressValue;

            if (progressValue >= 0.9f)
            {
                progressValue = 1;
                operation.allowSceneActivation = true;
            }

            yield return null;
        }
    }
}
