using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataPersistenceManager : MonoBehaviour {
    public static DataPersistenceManager instance { get; private set; }

    private FileDataHandler fileDataHandler;

    private void Awake() {
        if (instance != null){
            Debug.LogWarning("More than one instance of Data Persistance Manager exists");
        }
        instance = this;

        fileDataHandler = new FileDataHandler(Application.persistentDataPath, fileName);
    }

    public void SaveQuestData(Quest quest){
        foreach (quest in questMap.Values){
            fileDataHandler.saveQuestData(quest, PlayerPosition.transform.position);
        }
    }

    public Quest loadQuestData(QuestInfoSO questInfo, bool loadQuestState){
        return fileDataHandler.loadQuestData(questInfo, loadQuestState);
    }
}