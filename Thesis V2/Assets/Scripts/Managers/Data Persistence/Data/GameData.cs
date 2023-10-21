using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class GameData {
    // * NPC Variables
    public SerializableDictionary<string, Transform> NPCTargetMap;
    public SerializableDictionary<string, int> NPCFloorMap;
    public SerializableDictionary<string, bool> NPCIsLayingDownMap;
    public SerializableDictionary<string, bool> NPCIsSickMap;
    public SerializableDictionary<string, bool> NPCIsSittingMap;
    public SerializableDictionary<string, Vector3> NPCposition;
    public float timerData;

    // * Player Variables
    public Vector3 playerPosition;

    // * Item Variables
    public int gloveUsesData;
    public int alcoholUsesData;
    public int maskUsesData;

    public GameData(){
        this.playerPosition = Vector3.zero;

        this.NPCTargetMap = new SerializableDictionary<string, Transform>();
        this.NPCIsLayingDownMap = new SerializableDictionary<string, bool>();
        this.NPCIsSickMap = new SerializableDictionary<string, bool>();
        this.NPCIsSittingMap = new SerializableDictionary<string, bool>();

        this.timerData = 3600f;

        this.gloveUsesData = 0;
        this.alcoholUsesData = 0;
        this.maskUsesData = 0;

        // ! These two causes issues because it initializes to either null or 0
        this.NPCFloorMap = new SerializableDictionary<string, int>();
        this.NPCposition = new SerializableDictionary<string, Vector3>();
    }
}