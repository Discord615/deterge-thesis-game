using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PauseScript : MonoBehaviour
{
    [SerializeField] private GameObject pauseOverlay;
    [SerializeField] private GameObject[] pauseMenuChoices;
    bool overlayBool;
    
    private void Start() {
        pauseOverlay.SetActive(false);
        overlayBool = false;
        Time.timeScale = 1;
    }

    private void Update() {
        if (!InputManager.getInstance().GetEscapedPressed()) return;
        
        if (DialogueManager.instance.dialogueIsPlaying){
            // Action Invalid Prompt
            return;
        }

        if (MinigameManager.instance.sequenceGame.activeInHierarchy || MinigameManager.instance.syringeGame.activeInHierarchy || MinigameManager.instance.onBeatGame.activeInHierarchy) return;

        togglePauseMenu();
    }

    // TODO: Add settings and return to main menu

    public void resume(){
        togglePauseMenu();
    }

    public void quit(){
        Application.Quit();
    }

    public void togglePauseMenu(){
        if (!overlayBool){
            pauseOverlay.SetActive(true);
            Time.timeScale = 0;
            StartCoroutine(SelectFirstChoice());
            overlayBool = true;
        } else {
            pauseOverlay.SetActive(false);
            Time.timeScale = 1;
            overlayBool = false;
        }
    }

    private IEnumerator SelectFirstChoice(){
        EventSystem.current.SetSelectedGameObject(null);
        yield return new WaitForEndOfFrame();
        EventSystem.current.SetSelectedGameObject(pauseMenuChoices[0].gameObject);
    }
}
