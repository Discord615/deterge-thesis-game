using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

[RequireComponent(typeof(BoxCollider))]
public class ProcessSamplesScriptFifth : QuestStep
{
    private GameObject objectiveOut;
    private GameObject visualCue;

    private void OnEnable() {
        GameEventsManager.instance.miscEvents.onWordSearchComplete += wordSearchComplete;
    }

    private void OnDisable() {
        GameEventsManager.instance.miscEvents.onWordSearchComplete -= wordSearchComplete;
    }

    private void Start() {
        objectiveOut = GameObject.Find("Objective");
        visualCue = VisualCueManager.instnace.questPointCue;

        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;

        WordsearchManager.Instance.wordsearchData = WordSearchSOManager.instance.TyphoidSymptoms;
        WordsearchManager.Instance.populateWSGrid();
        MinigameManager.instance.wordSearchQuestion.text = string.Format("Search for the symptoms of {0}", "Typhoid");

        MinigameManager.instance.playerHud.SetActive(false);
        MinigameManager.instance.wordSearch.SetActive(true);
    }

    private void wordSearchComplete(){
        MinigameManager.instance.playerHud.SetActive(true);
        MinigameManager.instance.wordSearch.SetActive(false);

        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;

        FinishQuestStep();
    }

    protected override void setQuestStepState(string state)
    {
        // No Need
    }
}
