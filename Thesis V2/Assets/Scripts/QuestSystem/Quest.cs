using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Quest
{
    public QuestInfoSO info;

    public QuestState state;
    public int currentQuestStepIndex;
    private QuestStepState[] questStepStates;

    public Quest(QuestInfoSO questInfo)
    {
        this.info = questInfo;
        this.state = QuestState.REQUIREMENTS_NOT_MET;
        this.currentQuestStepIndex = 0;
        this.questStepStates = new QuestStepState[info.questStepPrefabs.Length];

        for (int i = 0; i < questStepStates.Length; i++)
        {
            questStepStates[i] = new QuestStepState();
        }
    }

    public Quest(QuestInfoSO questInfo, QuestState questState, int currentQuestStepIndex, QuestStepState[] questStepStates)
    {
        this.info = questInfo;
        this.state = questState;
        this.currentQuestStepIndex = currentQuestStepIndex;
        this.questStepStates = questStepStates;

        if (this.questStepStates.Length != this.info.questStepPrefabs.Length)
        {
            Debug.LogError("Quest state prefabs and Quest step states have different lengths");
        }
    }

    public void moveToNextStep()
    {
        currentQuestStepIndex++;
    }

    public bool currentStepExists()
    {
        return currentQuestStepIndex < info.questStepPrefabs.Length;
    }

    public void instantiateCurrentQuestStep(Transform parentTransform)
    {
        GameObject questStepPrefab = getCurrentQuestStepPrefab();
        if (questStepPrefab != null)
        {
            QuestStep questStep = Object.Instantiate<GameObject>(questStepPrefab, parentTransform).GetComponent<QuestStep>();
            questStep.initializeQuestStep(info.id, currentQuestStepIndex, questStepStates[currentQuestStepIndex].state);
        }
    }

    private GameObject getCurrentQuestStepPrefab()
    {
        GameObject questStepPrefab = null;
        if (currentStepExists()) questStepPrefab = info.questStepPrefabs[currentQuestStepIndex];
        else Debug.LogWarning("CurrentQuestStepIndex was out of range");

        return questStepPrefab;
    }

    public void storeQuestStepState(QuestStepState questStepState, int stepIndex)
    {
        if (stepIndex < questStepStates.Length)
        {
            questStepStates[stepIndex].state = questStepState.state;
        }
        else
        {
            Debug.LogWarning("Step index was out of range");
        }
    }

    public QuestData getQuestData()
    {
        return new QuestData(state, currentQuestStepIndex, questStepStates);
    }
}
