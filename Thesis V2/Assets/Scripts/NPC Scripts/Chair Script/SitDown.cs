using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider))]
public class SitDown : MonoBehaviour
{
    private GameObject occupant = null;
    public bool occupied = false;
    private Vector3 prevPos;
    private GameObject chairSitPos;

    private void Start() {
        chairSitPos = transform.parent.gameObject;
    }

    private void OnTriggerEnter(Collider other) {
        if (other.tag != "npc") return;
        if (!other.GetComponent<Unit>().target.gameObject.Equals(gameObject)) return;
        if (occupied){
            getNewTarget(other.gameObject);
            return;
        }
        other.GetComponent<NPCAnimScript>().wantToSit = true;
    }

    private void OnTriggerStay(Collider other) {
        if (other.tag != "npc") return;
        if (!other.GetComponent<Unit>().target.gameObject.Equals(gameObject)) return;
        if (!(other.GetComponent<NPCAnimScript>().wantToSit ^ (other.GetComponent<NPCAnimScript>().isSitting && occupied))) return;
        if (other.GetComponent<NPCAnimScript>().isSitting != occupied) return;
        if (other.GetComponent<NPCAnimScript>().wantToSit) sitDownTrigger(other.GetComponent<Animator>(), other.gameObject);
        else standUpTrigger(other.GetComponent<Animator>(), other.gameObject);
    }

    private void sitDownTrigger(Animator animator, GameObject npc){
        animator.SetTrigger("SitDown");
        npc.GetComponent<NPCAnimScript>().isSitting = true;

        prevPos = new Vector3(0, npc.transform.position.y, 0);
        npc.transform.position = chairSitPos.transform.position;
        npc.transform.forward = chairSitPos.transform.forward;

        occupant = npc;
        occupied = true;

        StartCoroutine(sittingDuration(npc));
    }

    private void standUpTrigger(Animator animator, GameObject npc){
        animator.SetTrigger("StandUp");
        npc.GetComponent<NPCAnimScript>().isSitting = false;

        npc.transform.position -= npc.transform.forward * 10;
        npc.transform.position = new Vector3(npc.transform.position.x, prevPos.y, npc.transform.position.z);

        occupant = null;
        occupied = false;

        getNewTarget(npc);
    }

    private void getNewTarget(GameObject npc){
        Transform newTarget;
        while (true){
            try{
                newTarget = UnitTargetManager.GetInstance().getAnyGameObjectTarget(npc.GetComponent<Unit>().floor, npc).transform;
                break;
            }
            catch (System.Exception){
                continue;
            }
        }

        npc.GetComponent<Unit>().target = newTarget;
    }

    private IEnumerator sittingDuration(GameObject npc){
        yield return new WaitForSeconds(Random.Range(3, 10));
        npc.GetComponent<NPCAnimScript>().wantToSit = false;
    }
}
