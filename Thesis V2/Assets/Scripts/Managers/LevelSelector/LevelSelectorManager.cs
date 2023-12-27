using UnityEngine;
using UnityEngine.UI;

public class LevelSelectorManager : MonoBehaviour, IDataPersistence
{
    public static LevelSelectorManager instance;

    private void Awake() {
        if (instance != null){
            Debug.LogError("More than one instance of Level Selector Manager in current scene");
            Destroy(instance);
        }
        instance = this;
    }

    [SerializeField] private Button[] LevelButtons;
    SerializableDictionary<int, LevelButton> LevelButtonDict;

    private void Start() {
        setAvailabilityOfButtons();
    }

    void setAvailabilityOfButtons(){
        foreach (var levelButton in LevelButtonDict)
        {
            LevelButtons[levelButton.Key].interactable = levelButton.Value.isAvailable;
        }
    }

    public void selectLevel(int buttonId){
        LevelButtonDict[buttonId].goToScene();
    }

    public void LoadData(GameData data)
    {
        this.LevelButtonDict = data.LevelButtonDict;
    }

    public void SaveData(ref GameData data)
    {
        data.LevelButtonDict = this.LevelButtonDict;
    }
}
