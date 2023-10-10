using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Quest
{
    public QuestInfoSO info;

    public QuestState state;
    public int currentQuestStepIndex;

    public Quest(QuestInfoSO questInfo){
        this.info = questInfo;
        this.state = QuestState.REQUIREMENTS_NOT_MET;
        this.currentQuestStepIndex = 0;
    }

    public void moveToNextStep(){
        currentQuestStepIndex++;
    }

    public bool currentStepExists(){
        return currentQuestStepIndex < info.questStepPrefabs.Length;
    }

    public void instantiateCurrentQuestStep(Transform parentTransform){
        GameObject questStepPrefab = getCurrentQuestStepPrefab();
        if (questStepPrefab != null){
            QuestStep questStep = Object.Instantiate<GameObject>(questStepPrefab, parentTransform).GetComponent<QuestStep>();
            questStep.initializeQuestStep(info.id);
        }
    }

    private GameObject getCurrentQuestStepPrefab(){
        GameObject questStepPrefab = null;
        if (currentStepExists()) questStepPrefab = info.questStepPrefabs[currentQuestStepIndex];
        else Debug.LogWarning("CurrentQuestStepIndex was out of range");

        return questStepPrefab;
    }
}
