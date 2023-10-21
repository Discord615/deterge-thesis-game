using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GlobalTimerManagaer : MonoBehaviour, IDataPersistence
{
    [SerializeField] private TextMeshProUGUI globalTimer;
    private float initialTime;
    private bool timeOut = false;

    private void Update() {
        if (!timeOut){
            UpdateTimerText(initialTime);

            initialTime -= Time.deltaTime;

            if (initialTime <= 0) {
                initialTime = 0;
                timeOut = true;
            }
        }
    }

    private void UpdateTimerText(float time){
        float minutes = Mathf.FloorToInt(time / 60);
        float seconds = Mathf.FloorToInt(time % 60);

        globalTimer.text = string.Format("{0:00} : {1:00}", minutes, seconds);
    }

    public void LoadData(GameData data)
    {
        this.initialTime = data.timerData;
    }

    public void SaveData(ref GameData data)
    {
        data.timerData = this.initialTime;
    }
}
