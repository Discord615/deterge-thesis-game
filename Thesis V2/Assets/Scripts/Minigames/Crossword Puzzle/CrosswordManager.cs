using System.Collections;
using System.Collections.Generic;
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
    
    const int NumberOfLetters = 59;
    int lettersFound = 0;
    [SerializeField] GameObject gameCompletePanel;

    private void OnEnable() {
        GameEventsManager.instance.miscEvents.LetterFound += onLetterFound;
    }

    private void OnDisable() {
        GameEventsManager.instance.miscEvents.LetterFound -= onLetterFound;
    }

    public void onLetterFound(){
        lettersFound++;

        if (lettersFound >= (NumberOfLetters - (NumberOfLetters * 0.85))){
            gameCompletePanel.SetActive(true);
        }
    }
}
