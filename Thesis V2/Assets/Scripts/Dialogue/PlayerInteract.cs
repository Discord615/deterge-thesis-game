using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerInteract : MonoBehaviour
{
    [Header("Player Object")]
    [SerializeField] private GameObject player;
    [SerializeField] public GameObject cloth;

    // [SerializeField] DialogueAction dialogueAction;

    private void OnTriggerEnter(Collider collider){
        if (collider.tag == "NPC"){
            // dialogueAction.playerInRange = true;
            collider.GetComponent<DialogueAction>().playerInRange = true;
        }
    }

    private void OnTriggerExit(Collider collider){
        if (collider.tag == "NPC"){
            collider.GetComponent<DialogueAction>().playerInRange = false;
        }
    }
}
