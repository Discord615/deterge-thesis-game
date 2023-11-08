using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class GameData
{
    // * NPC Variables
    public SerializableDictionary<string, Vector3> NPCTargetMap;
    public SerializableDictionary<string, int> NPCFloorMap;
    public SerializableDictionary<string, bool> NPCIsLayingDownMap;
    public SerializableDictionary<string, bool> NPCIsSickMap;
    public SerializableDictionary<string, bool> NPCIsSittingMap;
    public SerializableDictionary<string, bool> NPCWantToSitMap;
    public SerializableDictionary<string, Vector3> NPCposition;
    public SerializableDictionary<string, TextAsset> inkJsonData;

    public float timerData;

    // * Player Variables
    public Vector3 playerPosition;

    // * Item Variables
    public bool itemsAreAvailableData;
    public int gloveUsesData;
    public int alcoholUsesData;
    public int maskUsesData;

    // * Virus Variables
    public bool tyhpoidIsActive;
    public bool tuberculosisIsActive;
    public bool dengueIsActive;
    public bool influenzaIsActive;
    public bool coronaIsActive;
    public bool rabiesIsActive;

    // * SitDown Variables
    public SerializableDictionary<string, Transform> occupantData;
    public SerializableDictionary<string, bool> occupiedData;

    // * LayDown Variables
    public SerializableDictionary<string, TextAsset> virusJsonData;
    public SerializableDictionary<string, string> occupantLDNameData;

    public GameData()
    {
        this.playerPosition = Vector3.zero;

        this.NPCTargetMap = new SerializableDictionary<string, Vector3>();
        this.NPCIsLayingDownMap = new SerializableDictionary<string, bool>();
        this.NPCIsSickMap = new SerializableDictionary<string, bool>();
        this.NPCIsSittingMap = new SerializableDictionary<string, bool>();
        this.NPCWantToSitMap = new SerializableDictionary<string, bool>();

        this.timerData = 3600f;

        this.itemsAreAvailableData = false;
        this.gloveUsesData = 0;
        this.alcoholUsesData = 0;
        this.maskUsesData = 0;

        this.tyhpoidIsActive = true;
        this.tuberculosisIsActive = false;
        this.dengueIsActive = false;
        this.influenzaIsActive = false;
        this.coronaIsActive = false;
        this.rabiesIsActive = false;

        this.occupantData = new SerializableDictionary<string, Transform>();
        this.occupiedData = new SerializableDictionary<string, bool>();

        this.virusJsonData = new SerializableDictionary<string, TextAsset>();
        this.occupantLDNameData = new SerializableDictionary<string, string>();

        // ! These two causes issues because it initializes to either null or 0
        this.NPCFloorMap = new SerializableDictionary<string, int>();
        this.NPCposition = new SerializableDictionary<string, Vector3>();


        // ! To Fix more properly
        this.inkJsonData = new SerializableDictionary<string, TextAsset>();
    }
}