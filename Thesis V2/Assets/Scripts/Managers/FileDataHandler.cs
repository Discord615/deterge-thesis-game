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
        string fullPath = System.IO.Path.Combine(filePath, fileName);

        Quest quest = null;

        if (File.Exists(fullPath) && !MenuToGamplayPass.instance.startNewGame)
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
                QuestData questData = JsonUtility.FromJson<QuestData>(dataToLoad);
                quest = new Quest(questInfo, questData.state, questData.currentQuestStepIndex, questData.questStepStates);

            }
            catch (System.Exception)
            {
                Debug.LogError("Failed to load save file");
            }
        }
        else
        {
            quest = new Quest(questInfo);
        }

        return quest;
    }

    public void save(Quest quest)
    {
        string fullPath = System.IO.Path.Combine(filePath, fileName);
        try
        {
            Directory.CreateDirectory(System.IO.Path.GetDirectoryName(fullPath));
            QuestData questData = quest.getQuestData();
            string serializedData = JsonUtility.ToJson(questData, true);
            using (FileStream stream = new FileStream(fullPath, FileMode.Create))
            {
                using (StreamWriter writer = new StreamWriter(stream))
                {
                    writer.Write(serializedData);
                }
            }
        }
        catch (System.Exception e)
        {
            Debug.LogError("Failed to save quest: " + e);
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
