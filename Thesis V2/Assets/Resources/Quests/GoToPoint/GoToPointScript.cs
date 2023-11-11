using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

[RequireComponent(typeof(BoxCollider))]
public class GoToPointScript : QuestStep
{
    private GameObject objectiveOut;

    private void Start() {
        objectiveOut = GameObject.Find("Objective");
    }

    private void Update() {
        objectiveOut.GetComponent<TextMeshProUGUI>().text = string.Format("{0}", QuestManager.instance.getQuestById(questId).info.displayName);
    }

    private void OnTriggerEnter(Collider other) {
        if (!other.tag.Equals("Player")) return;

        FinishQuestStep();
    }

    protected override void setQuestStepState(string state)
    {
        // No Need
    }
}
