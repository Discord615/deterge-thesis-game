using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SitDown : MonoBehaviour
{
    private GameObject occupant = null;
    public bool occupied = false;
    private Vector3 prevPos;

    private void OnTriggerEnter(Collider other) {
        if (other.tag != "npc") return;
        if (occupied){
            getNewTarget(other.gameObject);
            return;
        }
        other.GetComponent<NPCAnimScript>().wantToSit = true;
    }

    private void OnTriggerStay(Collider other) {
        if (other.tag != "npc") return;
        if (!(other.GetComponent<NPCAnimScript>().wantToSit ^ (other.GetComponent<NPCAnimScript>().isSitting && occupied))) return;
        if (other.GetComponent<NPCAnimScript>().isSitting != occupied) return;
        if (other.GetComponent<NPCAnimScript>().wantToSit) sitDownTrigger(other.GetComponent<Animator>(), other.gameObject);
        else standUpTrigger(other.GetComponent<Animator>(), other.gameObject);
    }

    private void sitDownTrigger(Animator animator, GameObject npc){
        animator.SetTrigger("SitDown");
        npc.GetComponent<NPCAnimScript>().isSitting = true;

        prevPos = npc.transform.position;
        npc.transform.position = gameObject.transform.position;
        npc.transform.forward = gameObject.transform.forward;

        occupant = npc;
        occupied = true;
    }

    private void standUpTrigger(Animator animator, GameObject npc){
        animator.SetTrigger("StandUp");
        npc.GetComponent<NPCAnimScript>().isSitting = false;

        npc.transform.position = prevPos;

        occupant = null;
        occupied = false;

        getNewTarget(npc);
    }

    private void getNewTarget(GameObject npc){
        Transform newTarget;
        while (true){
            try{
                newTarget = UnitTargetManager.GetInstance().getAnyGameObjectTarget(npc.GetComponent<Unit>().floor).transform;
                break;
            }
            catch (System.Exception){
                continue;
            }
        }

        npc.GetComponent<Unit>().target = newTarget;
    }
}
