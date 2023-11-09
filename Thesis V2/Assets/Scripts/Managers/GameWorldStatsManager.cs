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
    public bool tyhpoidIsActive = false;
    public bool tuberculosisIsActive = false;
    public bool dengueIsActive = false;
    public bool influenzaIsActive = false;
    public bool coronaIsActive = false;
    public bool rabiesIsActive = false;

    public void LoadData(GameData data)
    {
        this.tyhpoidIsActive = data.tyhpoidIsActive;
        this.tuberculosisIsActive = data.tuberculosisIsActive;
        this.dengueIsActive = data.dengueIsActive;
        this.influenzaIsActive = data.influenzaIsActive;
        this.coronaIsActive = data.coronaIsActive;
        this.rabiesIsActive = data.rabiesIsActive;
    }

    public void SaveData(ref GameData data)
    {
        data.tyhpoidIsActive = this.tyhpoidIsActive;
        data.tuberculosisIsActive = this.tuberculosisIsActive;
        data.dengueIsActive = this.dengueIsActive;
        data.influenzaIsActive = this.influenzaIsActive;
        data.coronaIsActive = this.coronaIsActive;
        data.rabiesIsActive = this.rabiesIsActive;
    }

}