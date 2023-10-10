using System;

public class QuestEvents
{
    public event Action<string> onStartQuest;

    public void startQuest(string id){
        if (onStartQuest != null) onStartQuest(id);
    }

    public event Action<string> onAdvanceQuest;

    public void advanceQuest(string id){
        if (onAdvanceQuest!= null) onAdvanceQuest(id);
    }

    public event Action<string> onFinishQuest;

    public void finishQuest(string id){
        if (onFinishQuest != null) onFinishQuest(id);
    }

    public event Action<Quest> onQuestStateChange;

    public void questStateChange(Quest quest){
        if (onQuestStateChange != null) onQuestStateChange(quest);
    }

    public event Action<string, int, QuestStepState> onQuestStepStateChange;

    public void questStepStateChange(string id, int stepIndex, QuestStepState questStepState){
        if (onQuestStepStateChange != null) onQuestStepStateChange(id, stepIndex, questStepState);
    }
}
