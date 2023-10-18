using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class characterData{ // TODO: add more
    public Vector3 playerPosition;
    public float playerHealth;

    public characterData(Vector3 playerPosition, float playerHealth){
        this.playerPosition = playerPosition;
        this.playerHealth = playerHealth;
    }
}