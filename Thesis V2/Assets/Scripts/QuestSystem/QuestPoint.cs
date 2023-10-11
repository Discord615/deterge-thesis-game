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

    private bool playerIsNear = false; // ! Might not need this because quest running should be based on Inky dialogue files. See line 35 for possible changes
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

    private void Update() { // ! This shouldn't be in Update() function. This should be changed to Inky Functions

        // if (inkyQuestCall(QuestState.CAN_START) && startPoint) {
        //     GameEventsManager.instance.questEvents.startQuest(questId);
        // } else if (inkyQuestCall(QuestState.CAN_FINISH) && startPoint) {
        //     GameEventsManager.instance.questEvents.finishQuest(questId);
        // }

        // * Another possible way of the inkyIntegration

        // private void inkyQuestControl(){
        //     if (currentQuestState.Equals(QuestState.CAN_START) && startPoint){
        //         GameEventsManager.instance.questEvents.startQuest(questId);
        //     } else if (currentQuestState.Equals(QuestState.CAN_FINISH) && finishPoint){
        //         GameEventsManager.instance.questEvents.finishQuest(questId);
        //     }
        // }

        // ? Commented code above is possible code for inky integration

        if (InputManager.getInstance().GetInteractPressed() && playerIsNear){
            if (currentQuestState.Equals(QuestState.CAN_START) && startPoint){ // ? Might not need startPoint bool.
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
