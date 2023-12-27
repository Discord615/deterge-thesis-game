using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

[RequireComponent(typeof(BoxCollider))]
public class DialogueAction : MonoBehaviour
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

    private void Start()
    {
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

        DialogueManager.instance.EnterDialogueMode(GetComponent<MiscScript>().isPatientZero ? GetComponent<MiscScript>().patientZeroConvo : inkJson);

        if (GetComponent<MiscScript>().isPatientZero) {
            GetComponent<MiscScript>().isGoingToBed = true;
        }
    }

    public void getNewInk()
    {
        inkJson = InkManager.instance.getRandomInk(isMale);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!other.tag.Equals("Player")) return;
        if (GetComponent<NPCAnimScript>().isLayingDown) return;

        interactCue.SetActive(!GetComponent<NPCAnimScript>().isSick || (GetComponent<MiscScript>().isPatientZero && !GetComponent<MiscScript>().isGoingToBed));
    }

    private void OnTriggerExit(Collider other)
    {
        if (!other.tag.Equals("Player")) return;

        interactCue.SetActive(false);
    }
}
