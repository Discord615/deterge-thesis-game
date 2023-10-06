using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueAction : MonoBehaviour
{
    [Header("Visual Cue")]
    [SerializeField] private GameObject visualCue;

    [Header("Ink JSON")]
    [SerializeField] private TextAsset inkJson;

    public bool playerInRange;

    private void Awake(){
        visualCue.SetActive(false);
    }

    void Update(){
        if (playerInRange && !DialogueManagaer.GetInstance().dialogueIsPlaying){
            visualCue.SetActive(true);
            if(InputManager.getInstance().GetInteractPressed()){
                DialogueManagaer.GetInstance().EnterDialogueMode(inkJson);
            }
        } 
        else {
            visualCue.SetActive(false);
        }
    }
}
