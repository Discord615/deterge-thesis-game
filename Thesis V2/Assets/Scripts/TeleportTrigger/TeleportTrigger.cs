using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class TeleportTrigger : MonoBehaviour
{
    [Header("Teleport To Object")]
    [SerializeField] private GameObject location;
    private bool teleportAvailable;
    private GameObject teleportee;

    [SerializeField] private GameObject visualCue;

    private void Start()
    {
        visualCue.SetActive(false);
    }


    private void Update()
    {
        if (teleportAvailable)
        {
            if (teleportee == null) return;

            if (InputManager.getInstance().GetInteractPressed())
            {
                TeleportManager.GetInstance().TeleportPlayer(teleportee, location.transform.position);
            }

            if (teleportee.tag == "npc")
            {
                TeleportManager.GetInstance().TeleportNPC(teleportee, location.transform.position);
            }
        }
    }


    private void OnTriggerEnter(Collider collider)
    {
        if (collider.tag == "Player")
        {
            visualCue.SetActive(true);
            teleportAvailable = true;
            teleportee = collider.gameObject;
        }

        if (collider.tag == "npc")
        {

            if (collider.GetComponent<Unit>().wantToTeleport)
            {
                collider.GetComponent<Unit>().floor = collider.GetComponent<Unit>().floor == 1 ? 2 : 1;
                collider.GetComponent<Unit>().wantToTeleport = false;
                teleportAvailable = true;
                teleportee = collider.gameObject;

                collider.GetComponent<Unit>().target = UnitTargetManager.GetInstance().getAnyGameObjectTarget(collider.GetComponent<Unit>().floor, collider.gameObject);
            }
        }
    }

    private void OnTriggerExit(Collider collider)
    {
        if (collider.tag == "Player")
        {
            visualCue.SetActive(false);
            teleportAvailable = false;
            teleportee = null;
        }

        if (collider.tag == "npc")
        {
            teleportAvailable = false;
            teleportee = null;
        }
    }
}
