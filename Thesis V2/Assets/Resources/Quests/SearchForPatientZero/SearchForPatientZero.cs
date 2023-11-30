using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

[RequireComponent(typeof(BoxCollider))]
public class SearchForPatientZero : QuestStep
{
    private GameObject objectiveOut;

    [SerializeField] private bool tuber;
    [SerializeField] private bool typhoid;
    [SerializeField] private bool covid;
    [SerializeField] private bool rabies;
    [SerializeField] private bool flu;
    [SerializeField] private bool dengue;

    private void Start() {
        ArrowManager.instance.target = Vector3.zero;
        objectiveOut = GameObject.Find("Objective");
        SicknessManager.instance.showPatientZero();
        DialogueManager.instance.EnterDialogueMode(InkManager.instance.searchRootInks[Random.Range(0, 3)]);
        objectiveOut.GetComponent<TextMeshProUGUI>().text = string.Format("{0}", "Search for patient zero around the school\nMarked Red");
    }

    private void OnEnable() {
        GameEventsManager.instance.miscEvents.onPatientZeroFound += patientZeroFound;
    }

    private void OnDisable() {
        GameEventsManager.instance.miscEvents.onPatientZeroFound -= patientZeroFound;
    }

    private void patientZeroFound(){
        SicknessManager.instance.getPatientZero().GetComponent<MiscScript>().isGoingToBed = true;
        FinishQuestStep();
    }

    protected override void setQuestStepState(string state)
    {
        throw new System.NotImplementedException();
    }
}
