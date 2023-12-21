using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class WordSearchTimer : MonoBehaviour
{
    float TimerLength = 120;
    TextMeshProUGUI textOut;

    private void Start() {
        textOut = GetComponent<TextMeshProUGUI>();
    }

    private void Update() {
        FormatAndDisplayTime(TimerLength);

        if (TimerLength > 0)
            TimerLength -= !gameObject.activeInHierarchy ? 0 : Time.deltaTime;
        else {
            TimerLength = 0;
            GameEventsManager.instance.miscEvents.wordSearchCompleted(); // ? Might be too jarring if it just closes the minigame immediately
        }
    }

    private void FormatAndDisplayTime(float timeToDisplay){
        if (timeToDisplay < 0)
            timeToDisplay = 0;
        else if (timeToDisplay > 0)
            timeToDisplay += 1;

        float minutes = Mathf.FloorToInt(timeToDisplay / 60);
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);

        textOut.text = string.Format("Time Left: {0:00}:{1:00}", minutes, seconds);
    }
}
