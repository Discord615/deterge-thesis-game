using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

[RequireComponent(typeof(BoxCollider))]
public class talkToCanteenScript : QuestStep
{
    private GameObject objectiveOut;

    private void Start() {
        objectiveOut = GameObject.Find("Objective");
    }

    private void Update() {
        objectiveOut.GetComponent<TextMeshProUGUI>().text = string.Format("{0}", QuestManager.instance.getQuestById(questId).info.displayName);
    }

    private void OnTriggerStay(Collider other)
    {
        FinishQuestStep();
    }

    protected override void setQuestStepState(string state)
    {
        // NO NEED
    }
}
