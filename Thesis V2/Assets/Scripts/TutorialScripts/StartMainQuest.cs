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
        Cursor.visible = false;
        
        if (MenuToGamplayPass.instance.startNewGame)
        {
            DialogueManager.instance.EnterDialogueMode(firstMainQuestDialogue);
        }

        Destroy(gameObject);
    }
}
