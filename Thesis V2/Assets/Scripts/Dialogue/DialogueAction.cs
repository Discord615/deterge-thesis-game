using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueAction : MonoBehaviour, IDataPersistence
{
    [Header("Visual Cue")]
    [SerializeField] private GameObject visualCue;

    [Header("Ink JSON")]
    [SerializeField] public TextAsset inkJson;

    [SerializeField] public bool isMale;

    [SerializeField] private string id;

    [ContextMenu("Generate guid for id")]
    private void GenerateGuid()
    {
        id = System.Guid.NewGuid().ToString();
    }

    public bool playerInRange;

    private void Awake()
    {
        visualCue.SetActive(false);
    }

    void Update()
    {
        if (gameObject.GetComponent<NPCAnimScript>().isSick || gameObject.GetComponent<NPCAnimScript>().isLayingDown) return;

        if (!playerInRange) // ! Forces Visual Cue to be off
        {
            visualCue.SetActive(false);
            return;
        }

        visualCue.SetActive(true);

        if (!InputManager.getInstance().GetInteractPressed())
        {
            return;
        }

        DialogueManagaer.GetInstance().EnterDialogueMode(inkJson);
    }

    public void LoadData(GameData data)
    {
        TextAsset inkJsonOut;
        if (!data.inkJsonData.TryGetValue(id, out inkJsonOut))
        {
            if (inkJson != null) return;
            this.inkJson = InkManager.instance.getRandomInk(isMale);
        }
        else
        {
            inkJson = inkJsonOut;
        }
    }

    public void SaveData(ref GameData data)
    {
        if (data.inkJsonData.ContainsKey(id))
        {
            data.inkJsonData.Remove(id);
        }
        data.inkJsonData.Add(id, inkJson);
    }
}
