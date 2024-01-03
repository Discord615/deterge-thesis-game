using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MainMenuManager : MonoBehaviour
{
    [SerializeField] private GameObject[] choices;
    [SerializeField] private GameObject settingsPanel;

    private void Start() {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }

    public void toggleSettings(){
        settingsPanel.SetActive(!settingsPanel.activeInHierarchy);
    }

    public void exit(){
        Application.Quit();
    }
}
