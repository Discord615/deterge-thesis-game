using System.Collections;
using UnityEngine;

public class resetBeat : MonoBehaviour
{
    private void Update()
    {
        if (!MinigameManager.instance.onBeatGame.activeInHierarchy) return;

        StartCoroutine(beat());
    }

    IEnumerator beat()
    {
        if (HeartTempo.instance.beat)
        {
            yield return new WaitForSeconds(0.4f);
            HeartTempo.instance.beat = false;
        }
    }
}