using UnityEngine;

public class GameWorldStatsManager : MonoBehaviour, IDataPersistence
{
    public static GameWorldStatsManager instance { get; private set; }

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogError("More than one instance of Game World Stats Manager exists in the current scene");
        }
        instance = this;
    }

    public bool isNewGame;
    public string activeVirusName;
    public int patientsKilled = 0;

    public GameObject winPanel;

    public bool hasFaceMask = false;
    public bool hasGlove = false;

    public void LoadData(GameData data)
    {
        this.activeVirusName = data.activeVirusData;
        this.hasFaceMask = data.hasFaceMaskData;
        this.hasGlove = data.hasGloveData;
        this.patientsKilled = data.patientsKilledData;
    }

    public void SaveData(ref GameData data)
    {
        data.activeVirusData = this.activeVirusName;
        data.hasFaceMaskData = this.hasFaceMask;
        data.hasGloveData = this.hasGlove;
        data.patientsKilledData = this.patientsKilled;
    }

}