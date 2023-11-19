using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EncyclopediaManager : MonoBehaviour
{
    public static EncyclopediaManager instance { get; private set; }

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogError("More than one instance of Encyclopedia Manager exists in the current scene");
        }
        instance = this;
    }

    [SerializeField] private TextAsset encyclopediaInk;

    private void Update()
    {
        if (!InputManager.getInstance().getEncyclopediaPressed()) return;

        DialogueManagaer.instance.EnterDialogueMode(encyclopediaInk);
    }
}
