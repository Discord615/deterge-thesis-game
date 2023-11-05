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

    private TextAsset virusJson;
    [SerializeField] private GameObject visualCue;

    private void OnTriggerStay(Collider other)
    {
        if (other.tag != "npc") return;

        bool npcLayingDown = other.GetComponent<NPCAnimScript>().isLayingDown;
        bool npcIsSick = other.GetComponent<NPCAnimScript>().isSick;

        if (!(npcIsSick ^ (npcLayingDown && occupied))) return;
        if (npcLayingDown != occupied) return;
        if (npcIsSick) layDownTrigger(other.GetComponent<Animator>(), other.gameObject);
        else standUpTrigger(other.GetComponent<Animator>(), other.gameObject);
    }

    private void layDownTrigger(Animator animator, GameObject npc)
    {
        animator.SetTrigger("LayDown");
        npc.GetComponent<NPCAnimScript>().isLayingDown = true;

        npc.GetComponent<CapsuleCollider>().enabled = false;
        previousPosition = npc.transform.position;
        npc.transform.position = new Vector3(transform.position.x, 0, transform.position.z + 2);
        npc.transform.forward = transform.forward;

        occupant = npc;
        occupied = true;
        virusJson = InkManager.instance.getVirusDialogue();
    }

    private void standUpTrigger(Animator animator, GameObject npc)
    {
        animator.SetTrigger("StandUp");
        npc.GetComponent<NPCAnimScript>().isLayingDown = false;
        npc.GetComponent<DialogueAction>().inkJson = InkManager.instance.getRandomInk(npc.GetComponent<DialogueAction>().isMale);

        npc.transform.position = previousPosition;
        npc.GetComponent<CapsuleCollider>().enabled = true;

        occupant = null;
        occupied = false;

        npc.GetComponent<Unit>().target = UnitTargetManager.GetInstance().getAnyGameObjectTarget(npc.GetComponent<Unit>().floor, npc).transform;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!other.tag.Equals("Player")) return;

        visualCue.SetActive(occupied);
    }

    private void OnTriggerStay(Collider other)
    {
        if (!other.tag.Equals("Player")) return;

        if (!visualCue.active) return;

        if (!InputManager.getInstance().GetInteractPressed()) return;

        DialogueManagaer.GetInstance().EnterDialogueMode(virusJson);
    }

    private void OnTriggerExit(Collider other)
    {
        if (!other.tag.Equals("Player")) return;

        visualCue.SetActive(false);
    }
}
