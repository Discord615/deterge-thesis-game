using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

[RequireComponent(typeof(BoxCollider))]
public class QuestPoint : MonoBehaviour
{
    [Header("Quest")]
    [SerializeField] private QuestInfoSO questInfoForPoint;

    [Header("Point Type")]
    [SerializeField] private bool startPoint;
    [SerializeField] private bool finishPoint;
    [SerializeField] private bool BypassDialogue;
    [SerializeField] private bool needInteract;

    private string questId;
    private QuestState currentQuestState;
    // [SerializeField] private GameObject QuestIconPrefab;

    GameObject questObject;
    public bool iconIsDestroyed = false;

    private void Awake()
    {
        questId = questInfoForPoint.id;
    }

    private void OnEnable()
    {
        GameEventsManager.instance.questEvents.onQuestStateChange += questStateChange;
    }

    private void OnDisable()
    {
        GameEventsManager.instance.questEvents.onQuestStateChange -= questStateChange;
    }

    private void OnTriggerStay(Collider other) {
        if (!other.tag.Equals("Player")) return;

        if (!(DialogueManagaer.instance.dialogueIsPlaying || BypassDialogue)) return;

        if (needInteract) 
            if (!InputManager.getInstance().GetInteractPressed() && !GameObject.Find("Interact Cue").activeInHierarchy) return;

        if (currentQuestState.Equals(QuestState.CAN_FINISH) && finishPoint)
        {
            GameEventsManager.instance.questEvents.finishQuest(questId);
        }

        if (currentQuestState.Equals(QuestState.CAN_START) && startPoint)
        {
            GameEventsManager.instance.questEvents.startQuest(questId);
        }
    }

    private void OnTriggerEnter(Collider other) {
        if (!other.tag.Equals("Player")) return;

        if (!needInteract) return;

        GameObject.Find("Interact Cue").SetActive(true);
    }

    private void OnTriggerExit(Collider other) {
        if (!other.tag.Equals("Player")) return;

        if (!needInteract) return;

        GameObject.Find("Interact Cue").SetActive(false);
    }

    // private void ShowQuestIcon(QuestState currentQuestState)
    // {
    //     questObject = Instantiate(QuestIconPrefab, transform.position, Quaternion.identity, transform);
    // }

    // private void SetQuestIconText(QuestState currentQuestState, bool startPoint, bool finishPoint)
    // {
    //     if (currentQuestState != QuestState.REQUIREMENTS_NOT_MET && questObject == null)
    //         ShowQuestIcon(currentQuestState);

    //     switch (currentQuestState)
    //     {
    //         case QuestState.REQUIREMENTS_NOT_MET:

    //         break;

    //         case QuestState.CAN_START:
    //             if (startPoint){
    //                 questObject.GetComponent<TextMeshPro>().text = "!";
    //                 questObject.GetComponent<TextMeshPro>().color = Color.green;
    //             }
    //         break;

    //         case QuestState.IN_PROGRESS:
    //             if (startPoint && !finishPoint){
    //                 Destroy(questObject);
    //             }
    //             if (finishPoint){
    //                 questObject.GetComponent<TextMeshPro>().text = "?";
    //                 questObject.GetComponent<TextMeshPro>().color = Color.grey;
    //             }
    //         break;

    //         case QuestState.CAN_FINISH:
    //             if (finishPoint){
    //                 questObject.GetComponent<TextMeshPro>().text = "?";
    //                 questObject.GetComponent<TextMeshPro>().color = Color.green;
    //             }
    //         break;

    //         case QuestState.FINISHED:
    //             Destroy(questObject);
    //         break;
    //     }
    // }

    private void questStateChange(Quest quest)
    {
        if (quest.info.id.Equals(questId))
        {
            currentQuestState = quest.state;

            // if (!iconIsDestroyed)
            //     SetQuestIconText(currentQuestState, startPoint, finishPoint);
        }
    }
}
