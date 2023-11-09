using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider))]
public class talkToCanteenScript : QuestStep
{
    public static talkToCanteenScript instance { get; private set; }

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogError("More than one instance of \"Talk To Canteen Quest\" exists in current scene");
        }
        instance = this;
    }

    private void OnTriggerStay(Collider other)
    {
        if (!other.tag.Equals("Player")) return;
        if (!DialogueManagaer.GetInstance().dialogueIsPlaying) return;
        FinishQuestStep();
    }

    protected override void setQuestStepState(string state)
    {
        // NO NEED
    }
}
