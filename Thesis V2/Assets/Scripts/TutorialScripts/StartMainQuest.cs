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
            SicknessManager.instance.spreadSickness();
            SicknessManager.instance.displayNumberOfSickStudents = true;
            GameWorldStatsManager.instance.activeVirusName = "tuber";
            DialogueManagaer.instance.EnterDialogueMode(firstMainQuestDialogue);
        }

        Destroy(gameObject);
    }
}
