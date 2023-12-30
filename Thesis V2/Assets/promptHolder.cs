using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class promptHolder : MonoBehaviour
{
    public static promptHolder instance { get; private set; }

    private void Awake() {
        if (instance != null){
            Debug.LogError("More than one instance of promptHolder in current scene");
        }
        instance = this;
    }

    public GameObject transitionPrompt;
}
