using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

[RequireComponent(typeof(BoxCollider))]
public class LayDown : MonoBehaviour
{
    public bool occupied = false;
    GameObject occupant = null;
    Vector3 previousPosition;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag != "npc") return;
        if (occupied) getNewTarget(other.gameObject);
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.tag != "npc") return;

        bool npcLayingDown = other.GetComponent<NPCAnimScript>().isLayingDown;
        bool npcIsSick = other.GetComponent<NPCAnimScript>().isSick;

        if (other.tag != "npc") return;
        if (!(npcIsSick ^ (npcLayingDown && occupied))) return;
        if (npcLayingDown != occupied) return;
        if (npcIsSick) layDownTrigger(other.GetComponent<Animator>(), other.gameObject);
        else standUpTrigger(other.GetComponent<Animator>(), other.gameObject);
    }

    private void getNewTarget(GameObject npc)
    {
        Transform newTarget;
        while (true)
        {
            try
            {
                newTarget = UnitTargetManager.GetInstance().getBedTarget(npc.GetComponent<Unit>().floor).transform;
                break;
            }
            catch (System.Exception)
            {
                continue;
            }
        }

        npc.GetComponent<Unit>().target = newTarget;
    }

    private void layDownTrigger(Animator animator, GameObject npc)
    {
        animator.SetTrigger("LayDown");
        npc.GetComponent<NPCAnimScript>().isLayingDown = true;
        npc.GetComponent<DialogueAction>().inkJson = InkManager.instance.getVirusDialogue();

        previousPosition = npc.transform.position;
        npc.transform.position = new Vector3(transform.position.x, -1, transform.position.z);
        npc.transform.forward = new Vector3(-1, 0, 0);

        occupant = npc;
        occupied = true;
    }

    private void standUpTrigger(Animator animator, GameObject npc)
    {
        animator.SetTrigger("StandUp");
        npc.GetComponent<NPCAnimScript>().isLayingDown = false;
        npc.GetComponent<DialogueAction>().inkJson = InkManager.instance.getRandomInk(npc.GetComponent<DialogueAction>().isMale);

        npc.transform.position = previousPosition;

        occupant = null;
        occupied = false;

        getNewTarget(npc);
    }
}
