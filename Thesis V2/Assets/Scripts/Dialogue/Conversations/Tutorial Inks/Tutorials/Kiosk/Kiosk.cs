using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider))]
public class Kiosk : MonoBehaviour
{
    private void OnTriggerEnter(Collider other) {
        if (!other.tag.Equals("Player")) return;
        VisualCueManager.instnace.sinkCue.SetActive(true);
    }

    private void OnTriggerExit(Collider other) {
        if (!other.tag.Equals("Player")) return;
        VisualCueManager.instnace.sinkCue.SetActive(false);
    }

    private void OnTriggerStay(Collider other) {
        if (!other.tag.Equals("Player")) return;
        if (!InputManager.getInstance().GetInteractPressed()) return;

        // ! Add Minigame

        TutorialManager.instance.toggleKiosk(); // This should be in the minigame completion
    }
}
