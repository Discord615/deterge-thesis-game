using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PressBeat : MonoBehaviour
{
    [SerializeField] private HeartTempo heartTempo;
    [SerializeField] private TextMeshProUGUI OnBeat;
    [SerializeField] private TextMeshProUGUI NotOnBeat;

    [SerializeField] private int onBeatCount;
    [SerializeField] private int notOnBeatCount;

    bool reset = false;

    private void Start() {
        resetValues();
    }

    private void Update() {
        if (gameObject.activeSelf && !reset){
            resetValues();
            reset = true;
        }

        if (onBeatCount >= 5){
            reset = false;
            MinigameManager.instance.playerHud.SetActive(true);
            MinigameManager.instance.onBeatGame.SetActive(false);
        } 

        if (notOnBeatCount >= 5){
            reset = false;
            GameObject.Find(AssigningBottleWithMeds.instance.npcPatient).GetComponent<NPCAnimScript>().isSick = false;
            AssigningBottleWithMeds.instance.bed.GetComponent<LayDown>().occupied = false;
            GameObject.Find(AssigningBottleWithMeds.instance.npcPatient).SetActive(false);
            GameEventsManager.instance.miscEvents.patientKilled();
            MinigameManager.instance.playerHud.SetActive(true);
            MinigameManager.instance.onBeatGame.SetActive(false);
        }

        StartCoroutine(showBeatText(heartTempo.beat));
    }

    public void resetValues(){
        onBeatCount = 0;
        notOnBeatCount = 0;
    }

    private IEnumerator showBeatText(bool beat){
        if (InputManager.getInstance().getSpacePressedImpulse()){
            if (beat){
                if (NotOnBeat.IsActive()) NotOnBeat.gameObject.SetActive(false); 
                OnBeat.gameObject.SetActive(true);
                onBeatCount++;
                yield return new WaitForSeconds(0.2f);
                OnBeat.gameObject.SetActive(false);
            } else {
                if (OnBeat.IsActive()) OnBeat.gameObject.SetActive(false); 
                NotOnBeat.gameObject.SetActive(true);
                notOnBeatCount++;
                yield return new WaitForSeconds(0.2f);
                NotOnBeat.gameObject.SetActive(false);
            }
        }
    }
}
