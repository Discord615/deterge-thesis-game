using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VisualCueManager : MonoBehaviour
{
    public static VisualCueManager instnace { get; private set; }

    private void Awake() {
        if (instnace != null){
            Debug.LogError("More than one instance of Visual Cue Manager exists in the current scene");
        }
        instnace = this;
    }

    public GameObject npcCue;
    public GameObject bedCue;
    public GameObject sinkCue;
    public GameObject teleportCue;
    public GameObject questPointCue;
    public GameObject sanitizeCue;

    private void Start() {
        npcCue.SetActive(false);
        bedCue.SetActive(false);
        sinkCue.SetActive(false);
        teleportCue.SetActive(false);
        questPointCue.SetActive(false);
        sanitizeCue.SetActive(false);
    }
}
