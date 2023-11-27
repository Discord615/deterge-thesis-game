using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider))]
public class InteractDummy : MonoBehaviour
{
    [SerializeField] private GameObject visualCue;
    private void Start()
    {
        visualCue.SetActive(false);
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
        TutorialManager.instance.continueTutorial();
        visualCue.SetActive(false);
        Destroy(this);
    }
}
