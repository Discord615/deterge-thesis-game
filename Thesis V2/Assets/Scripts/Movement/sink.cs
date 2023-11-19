using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider))]
public class sink : MonoBehaviour
{
    [SerializeField] private GameObject visualCue;

    private void Start()
    {
        visualCue.SetActive(false);
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            visualCue.SetActive(false);
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (!other.tag.Equals("Player")) return;
        visualCue.SetActive(true);
        if (!visualCue.activeInHierarchy) return;
        if (!InputManager.getInstance().GetInteractPressed()) return;
        PlayerHealthManager.instance.healthRestore(); // TODO: Change to not full restore
    }
}
