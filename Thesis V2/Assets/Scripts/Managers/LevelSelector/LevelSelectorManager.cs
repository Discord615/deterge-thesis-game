using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LevelSelectorManager : MonoBehaviour
{
    public static LevelSelectorManager instance { get; private set; }

    private void Awake() {
        if (instance != null){
            Debug.LogError("More than one instance of Level Selector Manager in current scene");
        }
        instance = this;
    }

    [SerializeField] private Button[] LevelButtons;

    [SerializeField] TMP_InputField bypassCodeInput;

    private void Start() {
        DataPersistenceManager.instance.LoadGame();

        setAvailabilityOfButtons();

        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }

    void setAvailabilityOfButtons(){
        foreach (var levelButton in LevelButtonDictScript.instance.LevelButtonDict)
        {
            Debug.Log(string.Format("KEY: {0}\nAVAILABILITY: {1}", levelButton.Key, levelButton.Value.isAvailable));
            LevelButtons[levelButton.Key].interactable = levelButton.Value.isAvailable;
        }
    }

    public void returnToMenu(){
        LoadingScreen.instance.LoadSceneInstant(0);
    }

    public void selectLevel(int buttonId){
        LevelButtonDictScript.instance.LevelButtonDict[buttonId].goToScene();
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
}
