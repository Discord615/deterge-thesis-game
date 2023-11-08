using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CurePatientsQuestStep : QuestStep
{
    private int patientsSaved = 0;
    private int patientsToBeSaved = 5;

    private void OnEnable() {
        GameEventsManager.instance.miscEvents.onPatientSaved += patientSaved;
    }

    private void OnDisable() {
        GameEventsManager.instance.miscEvents.onPatientSaved -= patientSaved;
    }

    private void patientSaved(){
        if (patientsSaved < patientsToBeSaved){
            patientsSaved++;

            PlayerHealthManager.instance.reduceHealth();
            GameObject.Find(AssigningBottleWithMeds.instance.npcPatient).GetComponent<NPCAnimScript>().isSick = false;
            MinigameManager.instance.syringeGame.SetActive(false);
            MinigameManager.instance.playerHud.SetActive(true);

            updateState();
        }

        if (patientsSaved >= patientsToBeSaved) FinishQuestStep();
    }

    private void updateState(){
        string state = patientsSaved.ToString();
        changeState(state);
    }

    protected override void setQuestStepState(string state)
    {
        this.patientsSaved = System.Int32.Parse(state);
        updateState();
    }
}
