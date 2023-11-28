using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class progressBarScript : MonoBehaviour
{
    private void OnEnable()
    {
        GameEventsManager.instance.miscEvents.onWordFound += wordFound;
    }

    private void OnDisable()
    {
        GameEventsManager.instance.miscEvents.onWordFound -= wordFound;
    }

    Slider wordProgress;

    [SerializeField] private float wordsGotten = 0;
    private float wordsToGet;
    private TextMeshProUGUI wordNumOut;

    private void Start()
    {
        wordProgress = GetComponent<Slider>();
        wordNumOut = GetComponentInChildren<TextMeshProUGUI>();
        wordsToGet = WordsearchManager.Instance.totalNumOfValidWords;

        wordNumOut.text = string.Format("{0} / {1}", wordsGotten, wordsToGet);
    }

    private void wordFound()
    {
        wordsGotten++;
        wordProgress.value = Mathf.Clamp01(wordsGotten / wordsToGet);
        wordNumOut.text = string.Format("{0} / {1}", wordsGotten, wordsToGet);

        if (wordProgress.value >= wordProgress.maxValue)
        {
            wordProgress.value = 0;
        }
    }
}
