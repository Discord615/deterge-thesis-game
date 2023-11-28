using UnityEngine;

public class updateHeart : MonoBehaviour
{
    private void Update()
    {
        if (!MinigameManager.instance.onBeatGame.activeInHierarchy) return;

        if (HeartTempo.instance.heartZScale < HeartTempo.instance.targetScale)
        {
            HeartTempo.instance.updateBeat = false;
        }
    }
}