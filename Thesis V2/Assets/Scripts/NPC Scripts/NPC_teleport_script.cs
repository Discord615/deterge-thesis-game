using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC_teleport_script : MonoBehaviour
{
    public bool wantToTeleport = false;

    private Unit NPCTarget;

    private void Start() {
        NPCTarget = gameObject.GetComponent<Unit>();
    }

    private void OnTriggerEnter(Collider other) {
        if (!other.tag.Equals("teleporter")) return;
        if (other.gameObject == NPCTarget.target.gameObject){
            wantToTeleport = true;
        } else{
            wantToTeleport = false;
        }
    }
}
