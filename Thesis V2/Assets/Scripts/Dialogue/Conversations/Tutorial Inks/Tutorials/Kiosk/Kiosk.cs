using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider))]
public class Kiosk : MonoBehaviour
{
    private void OnEnable()
    {
        GameEventsManager.instance.miscEvents.onWordSearchComplete += wordSearchCompleted;
    }

    private void OnDisable()
    {
        GameEventsManager.instance.miscEvents.onWordSearchComplete -= wordSearchCompleted;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!other.tag.Equals("Player")) return;
        VisualCueManager.instnace.sinkCue.SetActive(true);
    }

    private void OnTriggerExit(Collider other)
    {
        if (!other.tag.Equals("Player")) return;
        VisualCueManager.instnace.sinkCue.SetActive(false);
    }

    private void OnTriggerStay(Collider other)
    {
        if (!other.tag.Equals("Player")) return;
        if (!InputManager.getInstance().GetInteractPressed()) return;

        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;

        MinigameManager.instance.playerHud.SetActive(false);
        MinigameManager.instance.wordSearch.SetActive(true);
    }

    private void wordSearchCompleted()
    {
        MinigameManager.instance.playerHud.SetActive(true);
        MinigameManager.instance.wordSearch.SetActive(false);
        TutorialManager.instance.toggleKiosk();
        TutorialManager.instance.continueTutorial();
    }
}
