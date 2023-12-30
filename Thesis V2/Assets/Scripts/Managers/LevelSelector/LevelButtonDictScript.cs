using UnityEngine;

public class LevelButtonDictScript : MonoBehaviour, IDataPersistence {
    public static LevelButtonDictScript instance { get; private set; }

    private void Awake() {
        if (instance != null){
            Destroy(this);
            Debug.LogError("More than one instance of LevelButtonDictScript");
        } else {
            instance = this;
        }
        DontDestroyOnLoad(instance);
    }

    public SerializableDictionary<int, LevelButton> LevelButtonDict;

    public void LoadData(GameData data)
    {
        LevelButtonDict = data.LevelButtonDict;
    }

    public void SaveData(ref GameData data)
    {
        data.LevelButtonDict = LevelButtonDict;
    }

}