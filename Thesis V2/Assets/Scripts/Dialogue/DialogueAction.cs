using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider))]
public class DialogueAction : MonoBehaviour, IDataPersistence
{
    [Header("Visual Cue")]
    [SerializeField] private GameObject interactCue;

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
        interactCue.SetActive(false);
    }

    void Update()
    {
        if (inkJson == null) inkJson = InkManager.instance.getRandomInk(isMale);

        if (gameObject.GetComponent<NPCAnimScript>().isSick || gameObject.GetComponent<NPCAnimScript>().isLayingDown) return;

        if (!interactCue.activeInHierarchy) return;

        if (!InputManager.getInstance().GetInteractPressed())
        {
            return;
        }

        DialogueManagaer.instance.EnterDialogueMode(inkJson);
    }

    private void OnTriggerEnter(Collider other) {
        if (!other.tag.Equals("Player")) return;

        interactCue.SetActive(true);
    }

    private void OnTriggerExit(Collider other) {
        if (!other.tag.Equals("Player")) return;

        interactCue.SetActive(false);
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
