using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class goToMainScene : MonoBehaviour
{
    bool stop = false;

    private void OnTriggerStay(Collider other)
    {
        if (!other.tag.Equals("Player")) return;

        if (TutorialManager.instance.tutorialIndex <= 0) return;

        if (DialogueManager.instance.dialogueIsPlaying) return;

        if (stop) return;

        stop = true;
        LoadingScreen.instance.LoadScene(2);
        Destroy(this);
    }
}
