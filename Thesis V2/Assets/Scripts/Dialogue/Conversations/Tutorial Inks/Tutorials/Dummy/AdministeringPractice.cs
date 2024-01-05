using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider))]
public class AdministeringPractice : MonoBehaviour
{
    [SerializeField] private GameObject visualCue;

    private void Start()
    {
        visualCue.SetActive(false);
    }

    private void OnEnable()
    {
        GameEventsManager.instance.miscEvents.onPatientSaved += patientSaved;
    }

    private void OnDisable()
    {
        GameEventsManager.instance.miscEvents.onPatientSaved -= patientSaved;
    }

    private void patientSaved()
    {
        MinigameManager.instance.playerHud.SetActive(true);
        MinigameManager.instance.syringeGame.SetActive(false);
        TutorialManager.instance.continueTutorial();
        Destroy(this);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!other.tag.Equals("Player")) return;
        visualCue.SetActive(true);
    }

    private void OnTriggerExit(Collider other)
    {
        if (!other.tag.Equals("Player")) return;
        visualCue.SetActive(false);
    }

    private void OnTriggerStay(Collider other)
    {
        if (!other.tag.Equals("Player")) return;
        if (!visualCue.activeInHierarchy) return;
        if (!InputManager.getInstance().GetInteractPressed()) return;
        visualCue.SetActive(false);
        SyringeBehaviour.instance.resetValues();
        DialogueManager.instance.EndDialogue();
        MinigameManager.instance.playerHud.SetActive(false);
        MinigameManager.instance.syringeGame.SetActive(true);
        AssigningBottleWithMeds.instance.setBottleNames(GameWorldStatsManager.instance.activeVirusName, true);
    }
}
