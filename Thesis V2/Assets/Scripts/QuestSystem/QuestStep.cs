using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class QuestStep : MonoBehaviour
{
    private bool isFinished = false;
    public string questId { get; private set; }
    private int stepIndex;

    public void initializeQuestStep(string questId, int stepIndex, string questStepState)
    {
        this.questId = questId;
        this.stepIndex = stepIndex;
        if (questStepState != null && questStepState != "")
        {
            setQuestStepState(questStepState);
        }
    }

    protected void FinishQuestStep()
    {
        if (!isFinished)
        {
            isFinished = true;
            GameEventsManager.instance.questEvents.advanceQuest(questId);
            Destroy(this.gameObject);
        }
    }

    protected void changeState(string newState)
    {
        GameEventsManager.instance.questEvents.questStepStateChange(questId, stepIndex, new QuestStepState(newState));
    }

    protected abstract void setQuestStepState(string state);
}
