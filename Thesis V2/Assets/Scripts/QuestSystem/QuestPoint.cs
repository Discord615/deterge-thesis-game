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
    private GameObject interactCue;

    private string questId;
    private QuestState currentQuestState;

    public bool iconIsDestroyed = false;

    private void Awake()
    {
        questId = questInfoForPoint.id;
    }

    private void Start() {
        interactCue = VisualCueManager.instnace.questPointCue;
    }

    private void OnEnable()
    {
        GameEventsManager.instance.questEvents.onQuestStateChange += questStateChange;
    }

    private void OnDisable()
    {
        GameEventsManager.instance.questEvents.onQuestStateChange -= questStateChange;
    }

    private void Update() {
        if (currentQuestState.Equals(QuestState.REQUIREMENTS_NOT_MET) || currentQuestState.Equals(QuestState.IN_PROGRESS))
            GetComponent<BoxCollider>().enabled = false;
        else 
            GetComponent<BoxCollider>().enabled = true;
    }

    private void OnTriggerStay(Collider other) {
        if (!other.tag.Equals("Player")) return;

        if (!(DialogueManager.instance.dialogueIsPlaying || BypassDialogue)) return;

        if (needInteract) if (!InputManager.getInstance().GetInteractPressed()) return;

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

        interactCue.SetActive(true);
    }

    private void OnTriggerExit(Collider other) {
        if (!other.tag.Equals("Player")) return;

        interactCue.SetActive(false);
    }

    private void questStateChange(Quest quest)
    {
        if (quest.info.id.Equals(questId))
        {
            currentQuestState = quest.state;
        }
    }
}
