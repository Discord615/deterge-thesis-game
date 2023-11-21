using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider))]
public class PlayerInteracting : MonoBehaviour
{
    public static PlayerInteracting instance { get; private set; }

    private void Awake() {
        if (instance != null){
            Debug.LogError("More than one instance of Player Interacting exists in current scene");
        }
        instance = this;
    }

    public GameObject NPC;

    private void OnTriggerEnter(Collider other) {
        if (DialogueManager.instance.dialogueIsPlaying) return;
        if (!other.tag.Equals("npc")) return;

        NPC = other.gameObject;
    }
}
