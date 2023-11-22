using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;


public class GetDNAScriptLast : QuestStep
{
    private int samplesCollected = 0;
    private int samplesToCollect = 1;

    private GameObject objectiveOut;

    private void OnEnable()
    {
        GameEventsManager.instance.miscEvents.onSampleCollected += sampleCollected;
    }

    private void OnDisable()
    {
        GameEventsManager.instance.miscEvents.onSampleCollected -= sampleCollected;
    }

    private void Start()
    {
        ArrowManager.instance.target = Vector3.zero;
        samplesToCollect = getNumberOfSickStudents();
        objectiveOut = GameObject.Find("Objective");
    }

    private void Update()
    {
        objectiveOut.GetComponent<TextMeshProUGUI>().text = string.Format("{0}: {1} / {2}", "Get DNA Samples From Sick Students", samplesCollected, samplesToCollect);
    }

    private int getNumberOfSickStudents(){
        int result = 0;

        foreach (Transform student in GameObject.Find("Students").transform)
        {
            if (student.GetComponent<NPCAnimScript>().isSick) result++;
        }

        return result;
    }

    private void sampleCollected()
    {
        if (samplesCollected < samplesToCollect)
        {
            samplesCollected++;
            updateState();
        }

        if (samplesCollected >= samplesToCollect)
        {
            objectiveOut.GetComponent<TextMeshProUGUI>().text = "Send samples to Med Lab";
            ArrowManager.instance.target = new Vector3(-97.7900009f, 2.5f, 22.7199993f);
            FinishQuestStep();
        }
    }

    private void updateState()
    {
        string state = samplesCollected.ToString();
        changeState(state);
    }

    protected override void setQuestStepState(string state)
    {
        this.samplesCollected = System.Int32.Parse(state);
        updateState();
    }
}
