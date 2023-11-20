using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

[RequireComponent(typeof(BoxCollider))]
public class DialogueAction : MonoBehaviour, IDataPersistence
{
    private GameObject interactCue;

    [Header("Ink JSON")]

    [SerializeField] public bool isMale;

    [SerializeField] private string id;

    [ContextMenu("Generate guid for id")]
    private void GenerateGuid()
    {
        id = System.Guid.NewGuid().ToString();
    }

    private TextAsset inkJson;

    private bool tookWalkingSickInk;

    private void Start() {
        interactCue = VisualCueManager.instnace.npcCue;
        interactCue.SetActive(false);
    }

    private void Update()
    {
        if (inkJson == null || (!GetComponent<NPCAnimScript>().isSick && tookWalkingSickInk))
        {
            tookWalkingSickInk = false;
            getNewInk();
        }

        if (GetComponent<NPCAnimScript>().isSick && !tookWalkingSickInk)
        {
            tookWalkingSickInk = true;
            inkJson = InkManager.instance.getWalkingSickInk();
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (!other.tag.Equals("Player")) return;

        if (GetComponent<NPCAnimScript>().isLayingDown) return;

        if (!interactCue.activeInHierarchy) return;

        if (!InputManager.getInstance().GetInteractPressed()) return;

        DialogueManagaer.instance.EnterDialogueMode(inkJson);

        if (GetComponent<NPCAnimScript>().isSick)
        {
            GetComponent<NPCAnimScript>().goingToBed = true;

            GameEventsManager.instance.miscEvents.talkToStudent();
        }
    }

    public void getNewInk()
    {
        inkJson = InkManager.instance.getRandomInk(isMale);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!other.tag.Equals("Player")) return;

        interactCue.SetActive(!GetComponent<NPCAnimScript>().goingToBed);
    }

    private void OnTriggerExit(Collider other)
    {
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
