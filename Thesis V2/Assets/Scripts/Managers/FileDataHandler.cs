using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;

public class FileDataHandler
{
    private string fileName;
    private string filePath;

    public FileDataHandler(string filePath, string fileName){
        this.filePath = filePath;
        this.fileName = fileName;
    }

    public Quest load(QuestInfoSO questInfo, bool loadQuestState){
        string fullPath = System.IO.Path.Combine(filePath, fileName);

        Quest quest = null;

        if (!loadQuestState) {
            quest = new Quest(questInfo);
            return quest;
        }

        if (File.Exists(fullPath)){
            try
            {
                string dataToLoad = "";

                using(FileStream stream = new FileStream(fullPath, FileMode.Open)){
                    using (StreamReader reader = new StreamReader(stream)){
                        dataToLoad = reader.ReadToEnd();
                    }
                }
                QuestData questData = JsonUtility.FromJson<QuestData>(dataToLoad);
                quest = new Quest(questInfo, questData.state, questData.questStepIndex, questData.questStepStates);
            }
            catch (System.Exception)
            {
                Debug.LogError("Failed to load save file");
            }
        } else {
            quest = new Quest(questInfo);
        }

        return quest;
    }

    public Vector3 loadPlayerPos(){
        string fullPath = System.IO.Path.Combine(filePath, fileName);
        Vector3 playerPos = new Vector3(0, 1.16f, 0);

        if (File.Exists(fullPath)){
            try
            {
                string dataToLoad = "";

                using(FileStream stream = new FileStream(fullPath, FileMode.Open)){
                    using (StreamReader reader = new StreamReader(stream)){
                        dataToLoad = reader.ReadToEnd();
                    }
                }
                QuestData questData = JsonUtility.FromJson<QuestData>(dataToLoad);
                playerPos = questData.playerPosition;
            }
            catch (System.Exception)
            {
                Debug.LogError("Failed to load save file");
            }
        }

        return playerPos;
    }

    public void save(Quest quest, Vector3 PlayerPosition){
        string fullPath = System.IO.Path.Combine(filePath, fileName);
        try
        {
            Directory.CreateDirectory(System.IO.Path.GetDirectoryName(fullPath));

            QuestData questData = quest.getQuestData();
            questData.playerPosition = PlayerPosition;
            string serializedData = JsonUtility.ToJson(questData, true);
            using (FileStream stream = new FileStream(fullPath, FileMode.Create)){
                using (StreamWriter writer = new StreamWriter(stream)){
                    writer.Write(serializedData);
                }
            }
        }
        catch (System.Exception)
        {
            Debug.LogError("Failed to save quest");
        }
    }
}
