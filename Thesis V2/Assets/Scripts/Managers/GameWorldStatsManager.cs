using UnityEngine;

public class GameWorldStatsManager : MonoBehaviour, IDataPersistence
{
    public GameWorldStatsManager instance { get; private set; }

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogError("More than one instance of Game World Stats Manager exists in the current scene");
        }
        instance = this;
    }

    // ! Add other viruses here

    public bool tyhpoidIsActive = false;
    public bool tuberculosisIsActive = false;

    public void LoadData(GameData data)
    {
        this.tyhpoidIsActive = data.tyhpoidIsActive;
        this.tuberculosisIsActive = data.tuberculosisIsActive;
    }

    public void SaveData(ref GameData data)
    {
        data.tyhpoidIsActive = this.tyhpoidIsActive;
        data.tuberculosisIsActive = this.tuberculosisIsActive;
    }

}