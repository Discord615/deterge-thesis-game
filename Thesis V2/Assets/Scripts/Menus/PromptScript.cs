using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PromptScript : MonoBehaviour
{
    [SerializeField] private int levelNum;

    private void OnEnable() {
        if (levelNum >= LevelButtonDictScript.instance.LevelButtonDict.Count)
            return;

        LevelButtonDictScript.instance.LevelButtonDict[levelNum + 1].isAvailable = true;

        DataPersistenceManager.instance.SaveGame();
    }

    public void goBackToLevelSelect(){
        DataPersistenceManager.instance.SaveGame();

        LoadingScreen.instance.LoadSceneInstant(1);
    }

    public void goToNextLevel(){
        if (levelNum >= LevelButtonDictScript.instance.LevelButtonDict.Count)
            return; // ! This would mean that it is the last level

        DataPersistenceManager.instance.SaveGame();

        LoadingScreen.instance.LoadScene(LevelButtonDictScript.instance.LevelButtonDict[levelNum + 1].sceneId);
    }
}
