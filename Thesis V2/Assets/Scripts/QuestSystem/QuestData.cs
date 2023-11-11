using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class QuestData
{
    public QuestInfoSO info;
    public QuestState state;
    public int currentQuestStepIndex;
    public QuestStepState[] questStepStates;

    public QuestData(QuestInfoSO info, QuestState state, int currentQuestStepIndex, QuestStepState[] questStepStates)
    {
        this.info = info;
        this.state = state;
        this.currentQuestStepIndex = currentQuestStepIndex;
        this.questStepStates = questStepStates;
    }
}
