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

    private void Start() {
        timer.value = 0;
    }

    private void Update() {
        if (!stopTimer) updateTimer();
    }

    private void updateTimer(){
        timer.value += timerAccel * Time.deltaTime;

        if (timer.value >= timer.maxValue){
            timer.value = timer.maxValue;
            timeOut = true;
        }
    }

    public void correctLetter(){
        timer.value -= 0.5f;
    }
}
