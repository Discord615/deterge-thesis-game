using UnityEngine;
using System.Collections.Generic;
using Ink.Parsed;

public class InkManager : MonoBehaviour
{
    public static InkManager instance { get; private set; }

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogError("More than one instance of Ink Manager exists in the current scene");
        }
        instance = this;
    }

    [Header("Gendered Ink Dialogues")]
    [SerializeField] private TextAsset[] maleRandomInks;
    [SerializeField] private TextAsset[] femaleRandomInks;


    [Header("Administrating Meds Dialogue")]
    [SerializeField] private TextAsset[] giveMedsDialogue;

    [Header("Sick Walking NPC Dialogue")]
    [SerializeField] private TextAsset[] walkingSickInks;

    [Header("Get DNA Samples Dialogue")]
    [SerializeField] private TextAsset[] getDNASampleDialogue;
    
    [Header("Med Lab Results")]
    public TextAsset fluResult;
    public TextAsset dengueResult;
    public TextAsset covidResult;
    public TextAsset typhoidResult;
    public TextAsset tuberResult;
    public TextAsset rabiesResult;

    public TextAsset getWalkingSickInk()
    {
        return walkingSickInks[Random.Range(0, walkingSickInks.Length)];
    }


    public TextAsset getRandomInk(bool isMale)
    {
        if (isMale) return getMaleInk();
        return getFemaleInk();
    }

    private TextAsset getMaleInk()
    {
        return maleRandomInks[Random.Range(0, maleRandomInks.Length)];
    }

    private TextAsset getFemaleInk()
    {
        return femaleRandomInks[Random.Range(0, femaleRandomInks.Length)];
    }

    public TextAsset getDNASampleAcquisitionInk()
    {
        TextAsset result;

        result = getDNASampleDialogue[Random.Range(0, getDNASampleDialogue.Length)];

        return result;
    }

    public TextAsset getGiveMedsInk(){
        TextAsset result;

        result = giveMedsDialogue[Random.Range(0, giveMedsDialogue.Length)];

        return result;
    }
}