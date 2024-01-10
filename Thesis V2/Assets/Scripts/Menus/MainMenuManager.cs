using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MainMenuManager : MonoBehaviour
{
    public static MainMenuManager instance { get; private set; }

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogError("More than one instance of Main Menu Manager Exists in the current scene");
        }
        instance = this;
    }

    [SerializeField] private GameObject[] choices;
    [SerializeField] private GameObject settingsPanel;

    private void Start()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }

    public void toggleSettings()
    {
        settingsPanel.SetActive(!settingsPanel.activeInHierarchy);
    }

    public void exit()
    {
        Application.Quit();
    }
}
