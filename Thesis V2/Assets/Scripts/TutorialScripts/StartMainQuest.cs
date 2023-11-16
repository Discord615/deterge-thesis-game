using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class StartMainQuest : MonoBehaviour
{
    [SerializeField] private GameObject objectiveTaskTextOut;

    [SerializeField] private TextAsset firstMainQuestDialogue;

    private void Start()
    {
        if (MenuToGamplayPass.instance.startNewGame)
        {
            DialogueManagaer.instance.EnterDialogueMode(firstMainQuestDialogue);
        }

        Destroy(gameObject);
    }
}
