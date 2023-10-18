using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class npcData{ // TODO: add loading and Saving
    public string uniqueID;
    public int floor;
    public Vector3 npcPosition;
    public bool isSick;
    public bool isLayingDown;
    public bool isSitting;
    public GameObject target;

    public npcData(string uniqueID, int floor, Vector3 npcPosition, bool isSick, bool isLayingDown, bool isSitting, GameObject target){
        this.uniqueID = uniqueID;
        this.floor = floor;
        this.npcPosition = npcPosition;
        this.isSick = isSick;
        this.isLayingDown = isLayingDown;
        this.isSitting = isSitting;
        this.target = target;
    }
}