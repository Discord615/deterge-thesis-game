using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CapsuleCollider))]
public class QuestPoint : MonoBehaviour
{
    [Header("Quest")]
    [SerializeField] private QuestInfoSO questInfoForPoint;
    
    private string questId;
    private QuestState currentQuestState;

    private void Awake() {
        questId = questInfoForPoint.id;
    }

    private void OnEnable() {
        GameEventsManager.instance.questEvents.onQuestStateChange += questStateChange;
    }
    
    private void OnDisable() {
        GameEventsManager.instance.questEvents.onQuestStateChange -= questStateChange;
    }

    private void Update() {
        if (currentQuestState.Equals(QuestState.CAN_START) && DialogueManagaer.GetInstance().inkStart){
            GameEventsManager.instance.questEvents.startQuest(questId);
        } else if (currentQuestState.Equals(QuestState.CAN_FINISH) && DialogueManagaer.GetInstance().inkFinish){
            GameEventsManager.instance.questEvents.finishQuest(questId);
        }
    }

    private void questStateChange(Quest quest){
        if (quest.info.id.Equals(questId)){
            currentQuestState = quest.state;
        }
    }
}
