using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MainMenuManager : MonoBehaviour
{
    [SerializeField] private GameObject[] choices;
    [SerializeField] private GameObject settingsPanel;

    private void Start() {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        StartCoroutine(SelectFirstChoice(choices));
    }

    private IEnumerator SelectFirstChoice(GameObject[] selectables)
    {
        EventSystem.current.SetSelectedGameObject(null);
        yield return new WaitForEndOfFrame();
        EventSystem.current.SetSelectedGameObject(selectables[0].gameObject);
    }

    public void toggleSettings(){
        settingsPanel.SetActive(!settingsPanel.activeInHierarchy);
        Cursor.visible = settingsPanel.activeInHierarchy;

        if (settingsPanel.activeInHierarchy) {
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
            StopAllCoroutines();
        }
        else {
            StartCoroutine(SelectFirstChoice(choices));
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
        }
    }
}
