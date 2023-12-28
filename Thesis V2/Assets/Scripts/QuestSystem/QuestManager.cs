using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestManager : MonoBehaviour
{
    public static QuestManager instance { get; private set; }
    private Dictionary<string, Quest> questMap;

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogError("More than one instance of Quest Manager exists in current scene");
        }
        instance = this;

        questMap = createQuestMap();
    }

    private void OnEnable()
    {
        GameEventsManager.instance.questEvents.onStartQuest += startQuest;
        GameEventsManager.instance.questEvents.onAdvanceQuest += advanceQuest;
        GameEventsManager.instance.questEvents.onFinishQuest += finishQuest;

        GameEventsManager.instance.questEvents.onQuestStepStateChange += questStepStateChange;
    }

    private void OnDisable()
    {
        GameEventsManager.instance.questEvents.onStartQuest -= startQuest;
        GameEventsManager.instance.questEvents.onAdvanceQuest -= advanceQuest;
        GameEventsManager.instance.questEvents.onFinishQuest -= finishQuest;

        GameEventsManager.instance.questEvents.onQuestStepStateChange -= questStepStateChange;
    }

    private void Start()
    {
        foreach (Quest quest in questMap.Values)
        {
            print(quest.info.displayName + quest.state);
            if (quest.state == QuestState.IN_PROGRESS)
            {
                quest.instantiateCurrentQuestStep(this.transform);
            }

            GameEventsManager.instance.questEvents.questStateChange(quest);
        }
    }

    private void changeQuestState(string id, QuestState state)
    {
        Quest quest = getQuestById(id);
        quest.state = state;
        GameEventsManager.instance.questEvents.questStateChange(quest);
    }

    private bool checkRequirementsMet(Quest quest)
    {
        bool meetsRequirements = true;

        foreach (QuestInfoSO prerequisiteQuestInfo in quest.info.questPrerequisites)
        {
            if (getQuestById(prerequisiteQuestInfo.id).state != QuestState.FINISHED) meetsRequirements = false;
        }

        return meetsRequirements;
    }

    private void Update()
    {
        foreach (Quest quest in questMap.Values)
        {
            if (quest.state == QuestState.REQUIREMENTS_NOT_MET && checkRequirementsMet(quest))
            {
                changeQuestState(quest.info.id, QuestState.CAN_START);
            }
        }
    }

    private void startQuest(string id)
    {
        Quest quest = getQuestById(id);
        quest.instantiateCurrentQuestStep(this.transform);
        changeQuestState(quest.info.id, QuestState.IN_PROGRESS);
    }

    private void advanceQuest(string id)
    {
        Quest quest = getQuestById(id);

        quest.moveToNextStep();

        if (quest.currentStepExists())
        {
            quest.instantiateCurrentQuestStep(this.transform);
        }
        else
        {
            changeQuestState(quest.info.id, QuestState.CAN_FINISH);
        }
    }

    private void finishQuest(string id)
    {
        Quest quest = getQuestById(id);
        changeQuestState(quest.info.id, QuestState.FINISHED);
    }

    private void questStepStateChange(string id, int stepIndex, QuestStepState questStepState)
    {
        Quest quest = getQuestById(id);
        quest.storeQuestStepState(questStepState, stepIndex);
        changeQuestState(id, quest.state);
    }

    private Dictionary<string, Quest> createQuestMap()
    {
        QuestInfoSO[] allQuest = Resources.LoadAll<QuestInfoSO>("Quests");

        foreach (QuestInfoSO item in allQuest)
        {
            Debug.Log(item.id);
        }

        Dictionary<string, Quest> idToQuestMap = new Dictionary<string, Quest>();

        foreach (QuestInfoSO questInfo in allQuest)
        {
            if (idToQuestMap.ContainsKey(questInfo.id)) Debug.LogWarning("Duplicate ID for " + questInfo.id + " exists");

            // idToQuestMap.Add(questInfo.id, fileDataHandler.loadQuests(questInfo));
            idToQuestMap.Add(questInfo.id, new Quest(questInfo));
        }

        return idToQuestMap;
    }

    public Quest getQuestById(string id)
    {
        Quest quest = questMap[id];
        if (quest == null) Debug.LogError("ID not found in quest map: " + id);
        return quest;
    }
}
