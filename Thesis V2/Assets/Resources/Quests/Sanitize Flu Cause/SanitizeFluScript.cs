using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

[RequireComponent(typeof(BoxCollider))]
public class SanitizeFluScript : QuestStep
{
    private GameObject sanitizeCue;
    private GameObject objectiveOut;

    private void Start() {
        sanitizeCue = VisualCueManager.instnace.sanitizeCue;

        objectiveOut.GetComponent<TextMeshProUGUI>().text = "Head to ventilations at 3rd Floor";
        objectiveOut = GameObject.Find("Objective");
        
        sanitizeCue.SetActive(false);
    }

    private void OnTriggerStay(Collider other) {
        if (!other.tag.Equals("Player")) return;
        sanitizeCue.SetActive(true);

        if (!InputManager.getInstance().GetInteractPressed()) return;

        objectiveOut.GetComponent<TextMeshProUGUI>().text = "Report to Med Lab";
        ArrowManager.instance.target = new Vector3(-97.7900009f, 2.5f, 22.7199993f);

        FinishQuestStep();
    }

    private void OnTriggerExit(Collider other) {
        if (!other.tag.Equals("Player")) return;
        sanitizeCue.SetActive(false);
    }


    protected override void setQuestStepState(string state)
    {
        // No Need
    }
}