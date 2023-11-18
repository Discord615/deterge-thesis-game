using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ProcessSamplesScript : QuestStep
{
    private GameObject objectiveOut;

    private void OnEnable() {
        GameEventsManager.instance.miscEvents.onSequenceCompleted += processSuccess;
        GameEventsManager.instance.miscEvents.onSequenceFailed += processFailed;
    }

    private void OnDisable() {
        GameEventsManager.instance.miscEvents.onSequenceCompleted -= processSuccess;
        GameEventsManager.instance.miscEvents.onSequenceFailed -= processFailed;
    }

    private void Start() {
        objectiveOut = GameObject.Find("Objective");
        
        MinigameManager.instance.playerHud.SetActive(false);
        MinigameManager.instance.sequenceGame.SetActive(true);
    }

    private void processSuccess(){
        MinigameManager.instance.playerHud.SetActive(true);
        MinigameManager.instance.sequenceGame.SetActive(false);
        FinishQuestStep();
    }

    private void processFailed(){
        MinigameManager.instance.playerHud.SetActive(true);
        MinigameManager.instance.sequenceGame.SetActive(false);
        objectiveOut.GetComponent<TextMeshProUGUI>().text = "Try Again";
    }


    protected override void setQuestStepState(string state)
    {
        // No Need
    }
}
