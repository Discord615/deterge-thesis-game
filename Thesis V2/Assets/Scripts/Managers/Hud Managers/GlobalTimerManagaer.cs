using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GlobalTimerManagaer : MonoBehaviour, IDataPersistence
{
    public static GlobalTimerManagaer instance { get; private set; }

    private void Awake() {
        if (instance != null){
            Debug.LogError("More than one instance of Global Timer Manager in current scene");
        }
        instance = this;
    }


    [SerializeField] private GameObject losePanel;
    [SerializeField] private TextMeshProUGUI globalTimer;
    private float initialTime = 900; // * 15 Minutes
    private bool timeOut = false;

    public bool pauseTimer = false;

    private void Start() {
        pauseTimer = false;
    }

    private void Update() {
        if (pauseTimer) return;

        if (!timeOut){
            UpdateTimerText(initialTime);

            initialTime -= Time.deltaTime;

            if (initialTime <= 0) {
                initialTime = 0;
                timeOut = true;
                losePanel.SetActive(true);
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
