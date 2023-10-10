using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// ! Not sure if this is needed for our case
// ! Might Already Exist in DialogueAction.cs script

[RequireComponent(typeof(BoxCollider))]
public class QuestPoint : MonoBehaviour
{
    [Header("Quest")]
    [SerializeField] private QuestInfoSO questInfoForPoint;

    [Header("Config")]
    [SerializeField] private bool startPoint = true;
    [SerializeField] private bool finishPoint = true;

    private bool playerIsNear = false;
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
        // ! quest control should be in inky dialogue
        if (InputManager.getInstance().GetInteractPressed() && playerIsNear){
            if (currentQuestState.Equals(QuestState.CAN_START) && startPoint){
                GameEventsManager.instance.questEvents.startQuest(questId);
            } else if (currentQuestState.Equals(QuestState.CAN_FINISH) && finishPoint){
                GameEventsManager.instance.questEvents.finishQuest(questId);
            }
        }
    }

    private void questStateChange(Quest quest){
        if (quest.info.id.Equals(questId)){
            currentQuestState = quest.state;
        }
    }

    private void OnTriggerEnter(Collider other) {
        if (other.CompareTag("Player")){
            playerIsNear = true;
        }
    }

    private void OnTriggerExit(Collider other) {
        if (other.CompareTag("Player")){
            playerIsNear = false;
        }
    }
}
