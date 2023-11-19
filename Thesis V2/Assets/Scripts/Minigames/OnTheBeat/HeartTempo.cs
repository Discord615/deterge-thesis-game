using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class HeartTempo : MonoBehaviour
{
    [SerializeField] private GameObject heart;

    public bool beat = false;
    private bool updateBeat = true;
    [SerializeField] private float targetScale = 2.7f;
    [SerializeField] private float maxScale = 3f;
    float scaleChange = 0.1f;

    float heartZScale;

    Thread resetBeatThread;
    Thread resetUpdateBeatThread;
    Thread updateHeartBeatThread;
    private void Start() {
        resetBeatThread = new Thread(resetBeat);
        resetUpdateBeatThread = new Thread(resetUpdateBeat);
        updateHeartBeatThread = new Thread(updateHeart);
        resetBeatThread.Start();
        resetUpdateBeatThread.Start();
        updateHeartBeatThread.Start();
    }

    private void OnEnable() {
        resetBeatThread.Start();
        resetUpdateBeatThread.Start();
        updateHeartBeatThread.Start();
    }

    private void OnDisable() {
        resetBeatThread.Abort();
        resetUpdateBeatThread.Abort();
        updateHeartBeatThread.Abort();
    }

    private void Update() {
        heartZScale = heart.transform.localScale.z;

        if (!updateBeat) heart.transform.localScale = new Vector3(maxScale, maxScale, maxScale);
        
        heart.transform.localScale -= new Vector3(scaleChange, scaleChange, scaleChange);
    }

    private void updateHeart(){
        while (true){
            if (heartZScale < targetScale){
                updateBeat = false;
            }

            if (heartZScale < targetScale + 0.05f){
                beat = true;
            }
        }
    }

    private void resetUpdateBeat(){
        while (true){
            if (!updateBeat){
                updateBeat = true;
            }
        }
    }

    private void resetBeat(){
        while (true){
            if (beat) {
                Thread.Sleep(300);
                beat = false;
            }
        }
    }
}
