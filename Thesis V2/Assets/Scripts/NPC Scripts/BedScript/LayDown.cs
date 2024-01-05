using UnityEngine;

[RequireComponent(typeof(BoxCollider))]
public class LayDown : MonoBehaviour
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
    public bool reverseBeds = false;
    public bool playerHasMeds = false;

    public bool sampleTaken = false;
    private GameObject visualCue;
    private bool interacted = false;

    private void Start()
    {
        visualCue = VisualCueManager.instnace.bedCue;
        visualCue.SetActive(false);
    }

    private void OnEnable()
    {
        GameEventsManager.instance.miscEvents.onPlayerGetMeds += playerGetsMeds;
        GameEventsManager.instance.miscEvents.onPlayerLosesMeds += playerLostMeds;
        GameEventsManager.instance.miscEvents.onPlayerZeroMeds += playerZeroMeds;
        GameEventsManager.instance.miscEvents.onSampleCollected += sampleTook;
    }

    private void OnDisable()
    {
        GameEventsManager.instance.miscEvents.onPlayerGetMeds -= playerGetsMeds;
        GameEventsManager.instance.miscEvents.onPlayerLosesMeds -= playerLostMeds;
        GameEventsManager.instance.miscEvents.onPlayerZeroMeds -= playerZeroMeds;
        GameEventsManager.instance.miscEvents.onSampleCollected -= sampleTook;
    }

    private void playerGetsMeds()
    {
        if (occupied) playerHasMeds = true;
    }

    private void playerLostMeds(){
        if (!occupied) playerHasMeds = false;
        sampleTaken = false;
    }

    private void playerZeroMeds(){
        playerHasMeds = true;
        sampleTaken = true;
    }

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

        if (DialogueManager.instance.dialogueIsPlaying) DialogueManager.instance.EndDialogue();
        interacted = false;

        visualCue.SetActive(false);
    }


    private void layDownTrigger(Animator animator, GameObject npc)
    {
        animator.SetTrigger("LayDown");
        npc.GetComponent<NPCAnimScript>().isLayingDown = true;
        npc.GetComponent<MiscScript>().isGoingToBed = false;

        previousPosition = new Vector3(0, npc.transform.position.y, 0);
        npc.transform.position = new Vector3(transform.position.x, 1, transform.position.z + (reverseBeds ? -2 : 2));
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

        playerHasMeds = false;
        sampleTaken = false;
        occupantName = "";
        occupied = false;

        npc.GetComponent<Unit>().target = UnitTargetManager.GetInstance().getAnyGameObjectTarget(npc.GetComponent<Unit>().floor, npc);
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

        AssigningBottleWithMeds.instance.npcPatient = occupantName;
        AssigningBottleWithMeds.instance.bed = gameObject;

        if (sampleTaken && !playerHasMeds) return;

        if (!InputManager.getInstance().GetInteractPressed()) return;

        if (!visualCue.activeInHierarchy) return;

        if (DialogueManager.instance.dialogueIsPlaying) return;

        interacted = true;

        visualCue.SetActive(false);

        DialogueManager.instance.EnterDialogueMode(playerHasMeds ? InkManager.instance.getGiveMedsInk() : InkManager.instance.getDNASampleAcquisitionInk());
    }

    void sampleTook(){
        if (playerHasMeds) return;
        if (interacted) sampleTaken = true;
    }
}
