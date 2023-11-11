using UnityEngine;

[RequireComponent(typeof(BoxCollider))]
public class LayDown : MonoBehaviour, IDataPersistence
{
    [SerializeField] private string id;

    [ContextMenu("Generate guid for id")]
    private void GenerateGuid()
    {
        id = System.Guid.NewGuid().ToString();
    }

    public bool occupied = false;
    string occupantName;
    Vector3 previousPosition;

    [SerializeField] private GameObject visualCue;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag.Equals("Player"))
        {
            if (!occupied) return;

            visualCue.SetActive(true);
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.tag.Equals("npc"))
        {
            NPCAnimBehavior(other.gameObject);
        }

        EnterDialogue(other.gameObject);
    }

    private void OnTriggerExit(Collider other)
    {
        if (!other.tag.Equals("Player")) return;

        visualCue.SetActive(false);
    }


    private void layDownTrigger(Animator animator, GameObject npc)
    {
        animator.SetTrigger("LayDown");
        npc.GetComponent<NPCAnimScript>().isLayingDown = true;

        npc.GetComponent<BoxCollider>().enabled = false;
        previousPosition = new Vector3(0, npc.transform.position.y, 0);
        npc.transform.position = new Vector3(transform.position.x, 1, transform.position.z + 2);
        npc.transform.forward = transform.forward;

        occupantName = npc.name;
        occupied = true;
    }

    private void standUpTrigger(Animator animator, GameObject npc)
    {
        animator.SetTrigger("StandUp");
        npc.transform.position += npc.transform.forward * 11;
        npc.transform.position = new Vector3(npc.transform.position.x, previousPosition.y, npc.transform.position.z);

        npc.GetComponent<NPCAnimScript>().isLayingDown = false;
        npc.GetComponent<DialogueAction>().getNewInk();

        npc.GetComponent<CapsuleCollider>().enabled = true;

        occupantName = "";
        occupied = false;

        npc.GetComponent<Unit>().target = UnitTargetManager.GetInstance().getAnyGameObjectTarget(npc.GetComponent<Unit>().floor, npc).transform.position;
    }

    private void NPCAnimBehavior(GameObject npc)
    {
        if (!npc.GetComponent<Unit>().target.Equals(new Vector3(transform.position.x, 0, transform.position.z))) return;

        bool npcLayingDown = npc.GetComponent<NPCAnimScript>().isLayingDown;
        bool npcIsSick = npc.GetComponent<NPCAnimScript>().isSick;

        if (!(npcIsSick ^ (npcLayingDown && occupied))) return;
        if (npcLayingDown != occupied) return;
        if (npcIsSick && !npcLayingDown) layDownTrigger(npc.GetComponent<Animator>(), npc);
        else if (!npcIsSick) standUpTrigger(npc.GetComponent<Animator>(), npc.gameObject);
    }

    private void EnterDialogue(GameObject other)
    {
        if (!other.tag.Equals("Player")) return;
        visualCue.SetActive(true);

        AssigningBottleWithMeds.instance.npcPatient = occupantName;
        AssigningBottleWithMeds.instance.bed = gameObject;

        if (!InputManager.getInstance().GetInteractPressed()) return;
        if (!occupied) return;

        DialogueManagaer.instance.EnterDialogueMode(InkManager.instance.getVirusDialogue());
    }

    public void LoadData(GameData data)
    {
        string occupantOutPut;
        if (data.occupantLDNameData.TryGetValue(id, out occupantOutPut))
        {
            if (occupantOutPut == "") return;
            GameObject.Find(occupantOutPut).GetComponent<NPCAnimScript>().isLayingDown = false;
            layDownTrigger(GameObject.Find(occupantOutPut).GetComponent<Animator>(), GameObject.Find(occupantOutPut));
        }
    }

    public void SaveData(ref GameData data)
    {
        if (data.occupantLDNameData.ContainsKey(id))
        {
            data.occupantLDNameData.Remove(id);
        }
        data.occupantLDNameData.Add(id, occupantName);
    }
}
