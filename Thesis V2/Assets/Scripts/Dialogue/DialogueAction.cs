using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueAction : MonoBehaviour, IDataPersistence
{
    [Header("Visual Cue")]
    [SerializeField] private GameObject visualCue;

    [Header("Ink JSON")]
    [SerializeField] private TextAsset inkJson;

    [SerializeField] private bool isMale;

    public bool playerInRange;

    private void Awake(){
        visualCue.SetActive(false);
    }

    void Update(){
        if (!(playerInRange && !DialogueManagaer.GetInstance().dialogueIsPlaying)){
            visualCue.SetActive(false);
            return;
        } 

        visualCue.SetActive(true);

        if(!InputManager.getInstance().GetInteractPressed()) return;

        DialogueManagaer.GetInstance().EnterDialogueMode(inkJson);
    }

    public void LoadData(GameData data){
        TextAsset output;
        if (data.inkJsonData.TryGetValue(GetComponent<Unit>().id, out output)){
            this.inkJson = output;
        } else {
            this.inkJson = InkManager.instance.getRandomInk(isMale);
        }
    }

    public void SaveData(ref GameData data){
        if (data.inkJsonData.ContainsKey(GetComponent<Unit>().id)){
            data.inkJsonData.Remove(GetComponent<Unit>().id);
        }
        data.inkJsonData.Add(GetComponent<Unit>().id, inkJson);
    }
}
