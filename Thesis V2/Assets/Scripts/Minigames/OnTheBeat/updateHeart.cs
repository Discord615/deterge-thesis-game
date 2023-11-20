using UnityEngine;

public class updateHeart : MonoBehaviour {
    private void Update() {
        if (!MinigameManager.instance.onBeatGame.activeInHierarchy) return;

        if (HeartTempo.instance.heartZScale < HeartTempo.instance.targetScale){
            Debug.Log(string.Format("HeartZ: {0}\nTarget: {1}", HeartTempo.instance.heartZScale, HeartTempo.instance.targetScale));
            HeartTempo.instance.updateBeat = false;
        }
    }
}