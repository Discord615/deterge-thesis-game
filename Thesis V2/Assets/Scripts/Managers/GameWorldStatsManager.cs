using UnityEngine;

public class GameWorldStatsManager : MonoBehaviour
{
    public static GameWorldStatsManager instance { get; private set; }

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogError("More than one instance of Game World Stats Manager exists in the current scene");
            Destroy(instance);
        }
        instance = this;
    }

    public string activeVirusName;
    public int patientsKilled = 0;

    public bool hasFaceMask = false;
    public bool hasGlove = false;
}