using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LevelSelectorManager : MonoBehaviour, IDataPersistence
{
    public static LevelSelectorManager instance { get; private set; }

    private void Awake() {
        if (instance != null){
            Debug.LogError("More than one instance of Level Selector Manager in current scene");
            Destroy(instance);
        }
        instance = this;
    }

    [SerializeField] private Button[] LevelButtons;
    SerializableDictionary<int, LevelButton> LevelButtonDict;

    [SerializeField] TMP_InputField bypassCodeInput;

    private void Start() {
        setAvailabilityOfButtons();

        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }

    void setAvailabilityOfButtons(){
        foreach (var levelButton in LevelButtonDict)
        {
            LevelButtons[levelButton.Key].interactable = levelButton.Value.isAvailable;
        }
    }

    public void returnToMenu(){
        LoadingScreen.instance.LoadSceneInstant(0);
    }

    public void selectLevel(int buttonId){
        LevelButtonDict[buttonId].goToScene();
    }

    public void bypass(){
        StartCoroutine(bypassLevels());
    }

    public IEnumerator bypassLevels(){
        string input = bypassCodeInput.text;

        if (!input.ToUpper().Equals("THESIS")){
            bypassCodeInput.image.color = Color.red;
            yield return new WaitForSeconds(0.5f);
            bypassCodeInput.image.color = Color.white;
            yield break;
        }

        foreach (var levelButton in LevelButtons)
        {
            levelButton.interactable = true;
        }

        bypassCodeInput.image.color = Color.green;
        yield return new WaitForSeconds(0.5f);
        bypassCodeInput.image.color = Color.white;
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
