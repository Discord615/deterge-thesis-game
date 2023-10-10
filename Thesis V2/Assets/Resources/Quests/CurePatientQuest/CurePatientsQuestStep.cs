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
        if (patientsSaved < patientsToBeSaved) patientsSaved++;

        if (patientsSaved >= patientsToBeSaved) FinishQuestStep();
    }
}
