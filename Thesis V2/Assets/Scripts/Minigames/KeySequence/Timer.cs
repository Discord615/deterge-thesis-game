using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    [SerializeField] private Slider timer;
    [SerializeField] private float timerAccel = 4f;
    public bool timeOut = false;
    public bool stopTimer = false;
    public bool startTimer = false;

    private void Start() {
        timer.value = timer.maxValue;
    }

    private void Update() {
        if (!stopTimer && startTimer) updateTimer();
    }

    private void updateTimer(){
        timer.value -= timerAccel * Time.deltaTime;

        if (timer.value <= timer.minValue){
            timer.value = timer.minValue;
            timeOut = true;
        }
    }

    public void correctLetter(){
        timer.value += 0.5f;
    }
}
