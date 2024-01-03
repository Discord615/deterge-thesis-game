using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CrosswordManager : MonoBehaviour
{
    public static CrosswordManager instance { get; private set; }

    private void Awake() {
        if (instance != null){
            Debug.LogError("There are more than one instance of Crossword Manager in current scene");
            Destroy(instance);
        }
        instance = this;
    }
    
    const int NumberOfLetters = 57;
    int lettersFound = 0;
    [SerializeField] GameObject gameCompletePanel;
    [SerializeField] private GameObject minigamePanel;

    [SerializeField] private TextMeshProUGUI finalScoreOutput;

    private void OnEnable() {
        GameEventsManager.instance.miscEvents.LetterFound += onLetterFound;
    }

    private void OnDisable() {
        GameEventsManager.instance.miscEvents.LetterFound -= onLetterFound;
    }

    public void checkCrossWord(){
        GameEventsManager.instance.miscEvents.onCompleteCrossword();
    }

    private void Update() {
        if (minigamePanel.activeInHierarchy) {
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }
    }

    public void onLetterFound(){
        lettersFound++;

        finalScoreOutput.text = string.Format("Final Score: {0}/57", lettersFound - 9);

        gameCompletePanel.SetActive(true);
    }
}
