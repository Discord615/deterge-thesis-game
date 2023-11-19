using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinigameManager : MonoBehaviour
{
    public static MinigameManager instance { get; private set; }

    private void Awake() {
        if (instance != null){
            Debug.LogError("More than one instance of Minigame Manager exists in current scene");
        }
        instance = this;
    }

    [Header("Minigame GameObjects")]
    public GameObject syringeGame;
    public GameObject onBeatGame;
    public GameObject sequenceGame;

    [Header("Game HUD")]
    public GameObject playerHud;

    private void Start() {
        syringeGame.SetActive(false);
        onBeatGame.SetActive(false);
        sequenceGame.SetActive(false);
    }
}
