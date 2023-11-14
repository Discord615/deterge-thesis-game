using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider))]
public class SitDown : MonoBehaviour, IDataPersistence
{
    [SerializeField] private string id;

    [ContextMenu("Generate guid for id")]
    private void GenerateGuid()
    {
        id = System.Guid.NewGuid().ToString();
    }

    private GameObject occupant;
    public bool occupied = false;
    private Vector3 prevPos;

    private void OnTriggerEnter(Collider other)
    {
        if (other == null) return;
        if (other.tag != "npc") return;
        if (other.GetComponent<Unit>().target == null) return;
        if (!other.GetComponent<Unit>().target.Equals(transform.position)) return;
        if (occupied)
        {
            getNewTarget(other.gameObject);
            return;
        }
        other.GetComponent<NPCAnimScript>().wantToSit = true;
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.tag != "npc") return;
        if (other.GetComponent<Unit>().target == null)
        {
            if (!other.GetComponent<NPCAnimScript>().isSitting) return;
            standUpTrigger(other.GetComponent<Animator>(), other.gameObject);
        }
        if (!other.GetComponent<Unit>().target.Equals(transform.position)) return;
        if (!(other.GetComponent<NPCAnimScript>().wantToSit ^ (other.GetComponent<NPCAnimScript>().isSitting && occupied))) return;
        if (other.GetComponent<NPCAnimScript>().isSitting != occupied) return;
        if (other.GetComponent<NPCAnimScript>().wantToSit) sitDownTrigger(other.GetComponent<Animator>(), other.gameObject);
    }

    private void sitDownTrigger(Animator animator, GameObject npc)
    {
        animator.SetTrigger("SitDown");
        npc.GetComponent<NPCAnimScript>().isSitting = true;

        prevPos = new Vector3(0, npc.transform.position.y, 0);
        npc.transform.position = gameObject.transform.GetChild(0).position;
        npc.transform.forward = gameObject.transform.GetChild(0).forward;

        occupant = npc;
        occupied = true;

        StartCoroutine(sittingDuration(npc));
    }

    private void standUpTrigger(Animator animator, GameObject npc)
    {
        animator.SetTrigger("StandUp");
        npc.GetComponent<NPCAnimScript>().isSitting = false;

        npc.transform.position -= npc.transform.forward * 6;
        npc.transform.position = new Vector3(npc.transform.position.x, prevPos.y, npc.transform.position.z);

        occupant = null;
        occupied = false;

        getNewTarget(npc);
    }

    private void getNewTarget(GameObject npc)
    {
        Vector3 newTarget;
        while (true)
        {
            try
            {
                newTarget = UnitTargetManager.GetInstance().getAnyGameObjectTarget(npc.GetComponent<Unit>().floor, npc);
                break;
            }
            catch (System.Exception)
            {
                continue;
            }
        }

        npc.GetComponent<Unit>().target = newTarget;
    }

    private IEnumerator sittingDuration(GameObject npc)
    {
        yield return new WaitForSeconds(Random.Range(3, 10));
        npc.GetComponent<NPCAnimScript>().wantToSit = false;
        standUpTrigger(npc.GetComponent<Animator>(), npc);
    }

    public void LoadData(GameData data)
    {
        Transform occupantTransform;
        data.occupantData.TryGetValue(id, out occupantTransform);
        if (occupantTransform != null)
        {
            occupant = occupantTransform.gameObject;
        }

        data.occupiedData.TryGetValue(id, out occupied);
    }

    public void SaveData(ref GameData data)
    {
        if (data.occupantData.ContainsKey(id))
        {
            data.occupantData.Remove(id);
        }
        if (occupant != null)
            data.occupantData.Add(id, occupant.transform);

        if (data.occupiedData.ContainsKey(id))
        {
            data.occupiedData.Remove(id);
        }
        data.occupiedData.Add(id, occupied);
    }
}
