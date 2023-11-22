using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class STOPNPC : MonoBehaviour
{
    [SerializeField] private bool isFirstFloor;
    private void OnCollisionEnter(Collision other) {
        if (!other.collider.tag.Equals("npc")) return;

        other.collider.GetComponent<Unit>().floor = isFirstFloor ? 1 : 2;
        TeleportManager.GetInstance().TeleportNPC(other.collider.gameObject, other.collider.GetComponent<Unit>().target);
        other.collider.GetComponent<NPCAnimScript>().stopped = true;
    }
}
