using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MovementTutorialScript : MonoBehaviour
{
    private Slider progress;
    public bool hasRun = false;

    private void Start()
    {
        progress = GetComponent<Slider>();
        progress.value = 0;
    }

    private void Update()
    {
        if (DialogueManager.instance.dialogueIsPlaying) return;
        if (InputManager.getInstance().GetMovePressed().Equals(Vector2.zero)) return;
        if (!hasRun) increaseProgress();
        else if (!InputManager.getInstance().GetRunPressed()) return;
        increaseProgress();
    }

    private void increaseProgress()
    {
        progress.value += 0.2f * Time.deltaTime;

        if (progress.value >= progress.maxValue)
        {
            Debug.Log("Maxed Progress");
            if (!hasRun) hasRun = true;
            progress.value = 0f;
            TutorialManager.instance.continueTutorial();
        }
    }
}
