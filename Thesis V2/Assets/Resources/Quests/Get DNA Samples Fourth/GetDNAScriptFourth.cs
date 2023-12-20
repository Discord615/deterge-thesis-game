using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;


public class GetDNAScriptFourth : QuestStep
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
        GameWorldStatsManager.instance.activeVirusName = "dengue";
        SicknessManager.instance.spreadSickness();
        ArrowManager.instance.target = new Vector3(-63.0946884f, -6.36458588f, 100.786087f);
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
            ArrowManager.instance.target = new Vector3(-76.2900009f, 1.05999994f, 21.6200008f);
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
