using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PressBeat : MonoBehaviour
{
    [SerializeField] private HeartTempo heartTempo;
    [SerializeField] private TextMeshProUGUI OnBeat;
    [SerializeField] private TextMeshProUGUI NotOnBeat;

    private void Update() {
        StartCoroutine(showBeatText(heartTempo.beat));
    }

    private IEnumerator showBeatText(bool beat){
        if (InputManager.getInstance().getSpacePressedImpulse()){
            if (beat){
                if (NotOnBeat.IsActive()) NotOnBeat.gameObject.SetActive(false); 
                OnBeat.gameObject.SetActive(true);
                yield return new WaitForSeconds(0.2f);
                OnBeat.gameObject.SetActive(false);
            } else {
                if (OnBeat.IsActive()) OnBeat.gameObject.SetActive(false); 
                NotOnBeat.gameObject.SetActive(true);
                yield return new WaitForSeconds(0.2f);
                NotOnBeat.gameObject.SetActive(false);
            }
        }
    }
}
