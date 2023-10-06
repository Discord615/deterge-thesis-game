using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class TeleportTrigger : MonoBehaviour
{
    [Header("Teleport To Object")]
    [SerializeField] private GameObject location;
    private bool teleportAvailable;
    private GameObject teleportee;


    private void Update(){
        if (teleportAvailable){
            if (teleportee == null) return;

            if (InputManager.getInstance().GetInteractPressed()){
                TeleportManager.GetInstance().TeleportPlayer(teleportee, location.transform.position);
            }

            if (teleportee.tag == "npc"){
                TeleportManager.GetInstance().TeleportNPC(teleportee, location.transform.position);
            }
        }
    }


    private void OnTriggerEnter(Collider collider){
        if (collider.tag == "Player"){
            teleportAvailable = true;
            teleportee = collider.gameObject;
        }
    }

    private void OnTriggerStay(Collider collider) {
        if (collider.tag == "npc"){
            if (collider.GetComponent<NPC_teleport_script>().wantToTeleport){
                teleportAvailable = true;
                teleportee = collider.gameObject;
            }
        }
    }

    private void OnTriggerExit(Collider collider){
        if (collider.tag == "Player"){
            teleportAvailable = false;
            teleportee = null;
        }

        if (collider.tag == "npc") {
            teleportAvailable = false;
            teleportee = null;
        }
    }
}
