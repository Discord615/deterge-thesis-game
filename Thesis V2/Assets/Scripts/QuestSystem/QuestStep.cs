using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class QuestStep : MonoBehaviour
{
    private bool isFinished = false;
    private string questId;

    public void initializeQuestStep(string questId){
        this.questId = questId;
    }

    protected void FinishQuestStep(){
        if (!isFinished){
            isFinished = true;
            GameEventsManager.instance.questEvents.advanceQuest(questId);
            Destroy(this.gameObject);
        }
    }
}
