using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class FindAndTalkScript : QuestStep
{
    private GameObject objectiveOut;

    private void OnEnable()
    {
        GameEventsManager.instance.miscEvents.onTalkToSickStudent += talkToStudent;
    }

    private void OnDisable()
    {
        GameEventsManager.instance.miscEvents.onTalkToSickStudent -= talkToStudent;
    }

    private void Start()
    {
        objectiveOut = GameObject.Find("Objective");
    }

    private void Update()
    {
        objectiveOut.GetComponent<TextMeshProUGUI>().text = string.Format("{0}: {1}", "Find and talk to sick students", SicknessManager.instance.numberOfSickStudents);
    }

    private void talkToStudent()
    {
        if (SicknessManager.instance.numberOfSickStudents > 0)
        {
            SicknessManager.instance.numberOfSickStudents--;

            updateState();
        }

        if (SicknessManager.instance.numberOfSickStudents <= 0)
        {
            objectiveOut.GetComponent<TextMeshProUGUI>().text = "Go to infirmary";

            FinishQuestStep();
        }
    }

    private void updateState()
    {
        string state = SicknessManager.instance.numberOfSickStudents.ToString();
        changeState(state);
    }

    protected override void setQuestStepState(string state)
    {
        SicknessManager.instance.numberOfSickStudents = System.Int32.Parse(state);
        updateState();
    }
}
