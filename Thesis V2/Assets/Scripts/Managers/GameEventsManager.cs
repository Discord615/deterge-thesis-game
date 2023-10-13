using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameEventsManager : MonoBehaviour
{
    public static GameEventsManager instance { get; private set; }

    public MiscEvents miscEvents;
    public QuestEvents questEvents;

    private void Awake() {
        if (instance != null){
            Debug.LogError("There are more than one instance of Game Event Manager");
        }
        instance = this;

        miscEvents = new MiscEvents();
        questEvents = new QuestEvents();
    }
}
