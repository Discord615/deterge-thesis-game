using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

[RequireComponent(typeof(BoxCollider))]
public class SearchForVirusPlace : QuestStep
{
    private GameObject objectiveOut;

    [SerializeField] private bool tuber;
    [SerializeField] private bool typhoid;
    [SerializeField] private bool covid;
    [SerializeField] private bool rabies;
    [SerializeField] private bool flu;
    [SerializeField] private bool dengue;

    private void Start() {
        objectiveOut = GameObject.Find("Objective");
    }

    private void Update() {
        objectiveOut.GetComponent<TextMeshProUGUI>().text = string.Format("{0}", "Search for virus around the school");
    }

    private void OnTriggerEnter(Collider other) {
        if (!other.tag.Equals("Player")) return;

        switch (GameWorldStatsManager.instance.activeVirusName)
        {
            case "tuber":
                if (tuber) FinishQuestStep();
                break;

            case "typhoid":
                if (typhoid) FinishQuestStep();
                break;

            case "covid":
                if (covid) FinishQuestStep();
                break;

            case "rabies":
                if (rabies) FinishQuestStep();
                break;

            case "flu":
                if (flu) FinishQuestStep();
                break;

            case "dengue":
                if (dengue) FinishQuestStep();
                break;
        }
    }

    protected override void setQuestStepState(string state)
    {
        throw new System.NotImplementedException();
    }
}
