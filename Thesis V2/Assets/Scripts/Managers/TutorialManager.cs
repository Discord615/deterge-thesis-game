using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialManager : MonoBehaviour
{
    public static TutorialManager instance { get; private set; }

    private void Awake() {
        if (instance != null){
            Debug.LogError("More than one instance of Tutorial Manager exists in current scene");
        }
        instance = this;
    }

    public TextAsset[] tutorialDialogue;
    public GameObject[] questPoints;

    private void Start() {
        foreach (GameObject questPoint in questPoints)
        {
            questPoint.SetActive(false);
        }

        DialogueManagaer.instance.EnterDialogueMode(tutorialDialogue[0]);
    }
}
