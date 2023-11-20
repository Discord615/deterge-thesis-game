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

    private GameObject visualCue;

    private void Start()
    {
        visualCue = VisualCueManager.instnace.teleportCue;
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

            if (collider.GetComponent<Unit>().wantToTeleport && collider.GetComponent<Unit>().target == new Vector3(transform.position.x, 0, transform.position.z))
            {
                collider.GetComponent<Unit>().floor = collider.GetComponent<Unit>().floor == 1 ? 2 : 1;
                collider.GetComponent<Unit>().wantToTeleport = false;
                teleportee = collider.gameObject;
                TeleportManager.GetInstance().TeleportNPC(teleportee, location.transform.position);

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
            teleportee = null;
        }
    }
}
