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
        ArrowManager.instance.target = Vector3.zero;
        objectiveOut = GameObject.Find("Objective");
        objectiveOut.GetComponent<TextMeshProUGUI>().text = string.Format("{0}", "Search for virus around the school");
    }

    private void OnTriggerEnter(Collider other) {
        if (!other.tag.Equals("Player")) return;

        switch (GameWorldStatsManager.instance.activeVirusName)
        {
            case "tuber":
                if (tuber) {
                    objectiveOut.GetComponent<TextMeshProUGUI>().text = "Report to the Med Lab to get cure for the root cause";
                    ArrowManager.instance.target = new Vector3(-97.7900009f, 2.5f, 22.7199993f);
                    FinishQuestStep();
                }
                break;

            case "typhoid":
                
                if (typhoid) {
                    objectiveOut.GetComponent<TextMeshProUGUI>().text = "Report to the Med Lab to get cure for the root cause";
                    ArrowManager.instance.target = new Vector3(-97.7900009f, 2.5f, 22.7199993f);
                    FinishQuestStep();
                }
                break;

            case "covid":
                if (covid) {
                    objectiveOut.GetComponent<TextMeshProUGUI>().text = "Report to the Med Lab to get cure for the root cause";
                    ArrowManager.instance.target = new Vector3(-97.7900009f, 2.5f, 22.7199993f);
                    FinishQuestStep();
                }
                break;

            case "rabies":
                if (rabies) {
                    objectiveOut.GetComponent<TextMeshProUGUI>().text = "Report to the Med Lab to get cure for the root cause";
                    ArrowManager.instance.target = new Vector3(-97.7900009f, 2.5f, 22.7199993f);
                    FinishQuestStep();
                }
                break;

            case "flu":
                if (flu) {
                    objectiveOut.GetComponent<TextMeshProUGUI>().text = "Report to the Med Lab to get cure for the root cause";
                    ArrowManager.instance.target = new Vector3(-97.7900009f, 2.5f, 22.7199993f);
                    FinishQuestStep();
                }
                break;

            case "dengue":
                if (dengue) {
                    objectiveOut.GetComponent<TextMeshProUGUI>().text = "Report to the Med Lab to get cure for the root cause";
                    ArrowManager.instance.target = new Vector3(-97.7900009f, 2.5f, 22.7199993f);
                    FinishQuestStep();
                }
                break;
        }
    }

    protected override void setQuestStepState(string state)
    {
        throw new System.NotImplementedException();
    }
}
