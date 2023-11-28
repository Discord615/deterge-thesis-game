using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WordSearchSOManager : MonoBehaviour
{
    public static WordSearchSOManager instance { get; private set; }
    private void Awake() {
        if (instance != null) Destroy(instance);
        instance = this;
    }

    public WordsearchData FluSymptoms;
    public WordsearchData TuberSymptoms;
    public WordsearchData DengueSymptoms;
    public WordsearchData CovidSymptoms;
    public WordsearchData RabiesSymptoms;
    public WordsearchData TyphoidSymptoms;
}
