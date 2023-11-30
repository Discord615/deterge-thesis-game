using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CurePatientsQuestStepThird : QuestStep
{
    private int patientsSaved = 0;
    private int patientsToBeSaved = 1;

    private GameObject objectiveOut;

    private void OnEnable()
    {
        GameEventsManager.instance.miscEvents.onPatientSaved += patientSaved;
        GameEventsManager.instance.miscEvents.onPatientKilled += patientKilled;
    }

    private void OnDisable()
    {
        GameEventsManager.instance.miscEvents.onPatientSaved -= patientSaved;
        GameEventsManager.instance.miscEvents.onPatientKilled -= patientKilled;
    }

    private void Start()
    {
        ArrowManager.instance.target = Vector3.zero;
        medLabResultStartDialogue();
        objectiveOut = GameObject.Find("Objective");
        GameEventsManager.instance.miscEvents.playerGetsMeds();
        patientsToBeSaved = getNumberOfSickStudents();
    }

    private void Update()
    {
        objectiveOut.GetComponent<TextMeshProUGUI>().text = string.Format("{0}: {1} / {2}", QuestManager.instance.getQuestById(questId).info.displayName, patientsSaved, patientsToBeSaved);

        if (patientsSaved >= patientsToBeSaved)
        {
            objectiveOut.GetComponent<TextMeshProUGUI>().text = "Report to Med Lab";
            ArrowManager.instance.target = new Vector3(-97.7900009f, 2.5f, 22.7199993f);
            FinishQuestStep();
        }
    }

    private void medLabResultStartDialogue(){
        switch (GameWorldStatsManager.instance.activeVirusName)
        {
            case "flu":
            DialogueManager.instance.EnterDialogueMode(InkManager.instance.fluResult);
            break;

            case "tuber":
            DialogueManager.instance.EnterDialogueMode(InkManager.instance.tuberResult);
            break;

            case "covid":
            DialogueManager.instance.EnterDialogueMode(InkManager.instance.covidResult);
            break;

            case "rabies":
            DialogueManager.instance.EnterDialogueMode(InkManager.instance.rabiesResult);
            break;

            case "typhoid":
            DialogueManager.instance.EnterDialogueMode(InkManager.instance.typhoidResult);
            break;

            case "dengue":
            DialogueManager.instance.EnterDialogueMode(InkManager.instance.dengueResult);
            break;
        }
    }

    private void patientSaved()
    {
        if (patientsSaved < patientsToBeSaved)
        {
            GameObject patient = GameObject.Find(AssigningBottleWithMeds.instance.npcPatient);
            patientsSaved++;

            MinigameManager.instance.syringeGame.SetActive(false);
            MinigameManager.instance.playerHud.SetActive(true);

            patient.GetComponent<NPCAnimScript>().isSick = false;
            patient.GetComponent<MiscScript>().isPatientZero = false;

            updateState();
        }
    }

    private void patientKilled(){
        patientsToBeSaved--;
    }

    private int getNumberOfSickStudents(){
        int result = 0;

        foreach (Transform student in GameObject.Find("Students").transform)
        {
            if (student.GetComponent<NPCAnimScript>().isSick) result++;
        }

        return result;
    }

    private void updateState()
    {
        string state = patientsSaved.ToString();
        changeState(state);
    }

    protected override void setQuestStepState(string state)
    {
        this.patientsSaved = System.Int32.Parse(state);
        updateState();
    }
}
