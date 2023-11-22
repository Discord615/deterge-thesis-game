using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

[RequireComponent(typeof(BoxCollider))]
public class ProcessSamplesScriptLast : QuestStep
{
    private GameObject objectiveOut;
    private GameObject visualCue;

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
        visualCue = VisualCueManager.instnace.questPointCue;

        MinigameManager.instance.playerHud.SetActive(false);
        MinigameManager.instance.sequenceGame.SetActive(true);
    }

    private void OnTriggerStay(Collider other) {
        if (!other.tag.Equals("Player")) return;

        visualCue.SetActive(true);

        if (!InputManager.getInstance().GetInteractPressed()) return;

        MinigameManager.instance.playerHud.SetActive(false);
        MinigameManager.instance.sequenceGame.SetActive(true);
    }

    private void OnTriggerExit(Collider other) {
        if (!other.tag.Equals("Player")) return;

        visualCue.SetActive(false);
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
