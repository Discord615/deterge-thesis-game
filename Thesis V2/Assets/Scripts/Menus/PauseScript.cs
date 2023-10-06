using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseScript : MonoBehaviour
{
    [SerializeField] private GameObject pauseOverlay;
    bool overlayBool;
    
    private void Start() {
        pauseOverlay.SetActive(false);
        overlayBool = false;
    }

    private void Update() {
        if (InputManager.getInstance().GetEscapedPressed()){
            if (!overlayBool){
                pauseOverlay.SetActive(true);
                Time.timeScale = 0;
                overlayBool = true;
            } else {
                pauseOverlay.SetActive(false);
                Time.timeScale = 1;
                overlayBool = false;
            }
        }
    }
}
