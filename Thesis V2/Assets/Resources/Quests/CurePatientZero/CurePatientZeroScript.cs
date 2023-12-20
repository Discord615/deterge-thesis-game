using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CurePatientZeroScript : QuestStep
{
    private GameObject sanitizeCue;
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

    private void Start() {
        ArrowManager.instance.target = Vector3.zero;
        objectiveOut = GameObject.Find("Objective");

        GameEventsManager.instance.miscEvents.playerGetsMeds();

        objectiveOut.GetComponent<TextMeshProUGUI>().text = "Cure Patient Zero";
    }

    private void patientSaved()
    {
        GameObject patient = GameObject.Find(AssigningBottleWithMeds.instance.npcPatient);

        MinigameManager.instance.syringeGame.SetActive(false);
        MinigameManager.instance.playerHud.SetActive(true);

        patient.GetComponent<NPCAnimScript>().isSick = false;
        patient.GetComponent<MiscScript>().isPatientZero = false;

        FinishQuestStepToDiffScene(Random.Range(4, 7));
        Finish();
    }

    private void patientKilled(){
        GameObject patient = GameObject.Find(AssigningBottleWithMeds.instance.npcPatient);

        MinigameManager.instance.onBeatGame.SetActive(false);
        MinigameManager.instance.playerHud.SetActive(true);

        patient.GetComponent<NPCAnimScript>().isSick = false;
        patient.GetComponent<MiscScript>().isPatientZero = false;

        // TODO: Lose? What do?
        Debug.LogError("Killing Patient Zero Is not implemented yet");
        FinishQuestStepToDiffScene(Random.Range(4, 7));
        Finish();
    }

    public void Finish(){
        
        GlobalTimerManagaer.instance.pauseTimer = true;
        GlobalTimerManagaer.instance.initialTime = 900;

        PlayerHealthManager.instance.player.transform.position = new Vector3(0, PlayerHealthManager.instance.player.transform.position.y, 0);

        DataPersistenceManager.instance.SaveGame();
        QuestManager.instance.saveQuests();
    }


    protected override void setQuestStepState(string state)
    {
        // No Need
    }
}
