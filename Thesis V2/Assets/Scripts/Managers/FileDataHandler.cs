using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;

public class FileDataHandler
{
    private string fileName;
    private string filePath;

    public FileDataHandler(string filePath, string fileName)
    {
        this.filePath = filePath;
        this.fileName = fileName;
    }

    public Quest loadQuests(QuestInfoSO questInfo)
    {
        Quest quest = null;

        try
        {
            if (PlayerPrefs.HasKey(questInfo.id) && !MenuToGamplayPass.instance.startNewGame){
                string serializedData = PlayerPrefs.GetString(questInfo.id);
                QuestData questData = JsonUtility.FromJson<QuestData>(serializedData);
                quest = new Quest(questInfo, questData.state, questData.currentQuestStepIndex, questData.questStepStates);
            }
            else {
                quest = new Quest(questInfo);
            }
        }
        catch (System.Exception)
        {
            Debug.LogError("Error occured while loading");
        }

        return quest;
    }

    public void save(Quest quest)
    {
        try
        {
            QuestData questData = quest.getQuestData();

            string serializedData = JsonUtility.ToJson(questData);

            PlayerPrefs.SetString(quest.info.id, serializedData);
        }
        catch (System.Exception)
        {
            Debug.LogError("Failed To Save Quest Data");
        }
    }

    public GameData Load()
    {
        string fullPath = System.IO.Path.Combine(filePath, fileName);
        GameData loadedData = null;

        if (File.Exists(fullPath))
        {
            try
            {
                string dataToLoad = "";

                using (FileStream stream = new FileStream(fullPath, FileMode.Open))
                {
                    using (StreamReader reader = new StreamReader(stream))
                    {
                        dataToLoad = reader.ReadToEnd();
                    }
                }

                loadedData = JsonUtility.FromJson<GameData>(dataToLoad);
            }
            catch (Exception)
            {
                Debug.LogWarning("Failed to load data");
            }
        }
        return loadedData;
    }

    public void Save(GameData data)
    {
        string fullPath = System.IO.Path.Combine(filePath, fileName);

        try
        {
            Directory.CreateDirectory(System.IO.Path.GetDirectoryName(fullPath));

            string dataToStore = JsonUtility.ToJson(data, true);

            using (FileStream stream = new FileStream(fullPath, FileMode.Create))
            {
                using (StreamWriter writer = new StreamWriter(stream))
                {
                    writer.Write(dataToStore);
                }
            }
        }
        catch (Exception)
        {
            Debug.LogWarning("Failed to save data");
        }
    }
}
