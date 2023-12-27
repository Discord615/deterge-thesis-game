using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class GameData
{
    #region Might not be needed anymore
        // // * NPC Variables
        // public SerializableDictionary<string, Vector3> NPCTargetMap;
        // public SerializableDictionary<string, int> NPCFloorMap;
        // public SerializableDictionary<string, bool> NPCIsLayingDownMap;
        // public SerializableDictionary<string, bool> NPCIsSickMap;
        // public SerializableDictionary<string, bool> NPCIsSittingMap;
        // public SerializableDictionary<string, bool> NPCWantToSitMap;
        // public SerializableDictionary<string, Vector3> NPCposition;
        // public SerializableDictionary<string, TextAsset> inkJsonData;

        // public float timerData;

        // // * Player Variables
        // public Vector3 playerPosition;

        // // * Item Variables
        // public bool itemsAreAvailableData;
        // public int gloveUsesData;
        // public int alcoholUsesData;
        // public int maskUsesData;

        // // * Virus Variables
        // public string activeVirusData;

        // public bool hasFaceMaskData;
        // public bool hasGloveData;
        // public float playerHealth;

        // // * SitDown Variables
        // public SerializableDictionary<string, Transform> occupantData;
        // public SerializableDictionary<string, bool> occupiedData;

        // // * LayDown Variables
        // public SerializableDictionary<string, TextAsset> virusJsonData;
        // public SerializableDictionary<string, string> occupantLDNameData;

        // // * Sickness Manager Variables
        // public int numberOfSickStudentsData;

        // // * General GameData
        // public int patientsKilledData;
    // ! Might not be needed anymore
    #endregion

    public SerializableDictionary<int, LevelButton> LevelButtonDict;

    public GameData()
    {
        #region Might not be needed anymore
        // this.playerPosition = new Vector3(0, 1, 0);

        // this.NPCTargetMap = new SerializableDictionary<string, Vector3>();
        // this.NPCIsLayingDownMap = new SerializableDictionary<string, bool>();
        // this.NPCIsSickMap = new SerializableDictionary<string, bool>();
        // this.NPCIsSittingMap = new SerializableDictionary<string, bool>();
        // this.NPCWantToSitMap = new SerializableDictionary<string, bool>();

        // this.timerData = 1800f;

        // this.itemsAreAvailableData = false;
        // this.gloveUsesData = 0;
        // this.alcoholUsesData = 0;
        // this.maskUsesData = 0;

        // this.activeVirusData = "tuber";
        // this.hasFaceMaskData = false;
        // this.hasGloveData = false;
        // this.playerHealth = 30f;

        // this.occupantData = new SerializableDictionary<string, Transform>();
        // this.occupiedData = new SerializableDictionary<string, bool>();

        // this.virusJsonData = new SerializableDictionary<string, TextAsset>();
        // this.occupantLDNameData = new SerializableDictionary<string, string>();

        // this.numberOfSickStudentsData = 0;

        // this.patientsKilledData = 0;

        // this.NPCFloorMap = new SerializableDictionary<string, int>();
        // this.NPCposition = new SerializableDictionary<string, Vector3>();

        // this.inkJsonData = new SerializableDictionary<string, TextAsset>();
        #endregion

        LevelButtonDict = new SerializableDictionary<int, LevelButton>(){
            {0, new LevelButton(1, true)},
            {1, new LevelButton(2, false)},
            {2, new LevelButton(4, false)},
            {3, new LevelButton(6, false)},
            {4, new LevelButton(8, false)},
            {5, new LevelButton(10, false)},
            {6, new LevelButton(12, false)},
            {7, new LevelButton(14, false)},
        };
    }
}